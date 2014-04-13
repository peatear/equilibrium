// kuntakinte.cpp
#include "pch.h"
#include "kuntakinte.h"

using namespace kuntakinte;
using namespace Platform;

flightbox::flightbox()
{

	//initialize cal value to 0
	this->mroll = 0;
	this->mpitch = 0;
	this->myaw = 0;

	//initialize duty cycle
	this->duty[0] = 0.2;
	this->duty[1] = 0.2;
	this->duty[2] = 0.2;
	this->duty[3] = 0.2;

	//set PID gain of roll loop
	this->kpr = 1;
	this->kir = 1;
	this->kdr = 1;

	//set PID gain of pitch loop
	this->kpp = 1;
	this->kip = 1;
	this->kdp = 1;

	//set PID gain of yaw loop
	this->kpy = 1;
	this->kiy = 1;
	this->kdy = 1;

}

int flightbox::calibrate(double roll, double pitch, double yaw){

	//set calibration value if there is offset
	this->mroll = roll;
	this->mpitch = pitch;
	this->myaw = yaw;

	return 0;

	
}

int flightbox::rollPID(double roll){
	return 0;
}

int flightbox::pitchPID(double roll){
	return 0;
}

int flightbox::yawPID(double yaw){
	return 0;
}

/*
int flightbox::balance(double roll, double pitch, double yaw){
	duty[0] = 0;
	duty[1] = 0;
	duty[2] = 0;
	duty[3] = 0;
	return 0;
}

*/