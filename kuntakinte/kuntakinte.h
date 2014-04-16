#pragma once

//this is what does all the work
namespace kuntakinte
{
    public ref class flightbox sealed
    {
	private:
		//roll pitch and yaw measurement
		double mroll;
		double mpitch;
		double myaw;

		//position
		double xpos;
		double ypos;
		double zpos;

		//duty cycle output to motor
		double duty[4];

		//PID gain of roll;
		double kpr; //proportional gain
		double kir; //integral gain
		double kdr; //derivative gain

		//PID gain of pitch;
		double kpp;//p gain
		double kip;//i gain
		double kdp;//d gain

		//PID gain of yaw;
		double kpy;//p gain
		double kiy;//i gain
		double kdy;//d gain

    public:
        flightbox();
		int calibrate(double roll, double pitch, double yaw);

		//int balance(double roll, double pitch, double yaw);

		int rollPID(double roll);

		int pitchPID(double pitch);

		int yawPID(double yaw);
		void OnReadingChanged(Windows::Devices::Sensors::Inclinometer ^sender, Windows::Devices::Sensors::InclinometerReadingChangedEventArgs ^args);
		void OnReadingChanged(Windows::Devices::Sensors::Accelerometer ^sender, Windows::Devices::Sensors::AccelerometerReadingChangedEventArgs ^args);
	};
}