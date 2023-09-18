#include "pch.h"
#include "sample.h"


// Constructor
Sample::Sample(int x) {
	this->x = x;
}

int Sample::add(int y) {
	return this->x + y;
}

int Sample::multiply(int y) {
	return this->x * y;
}