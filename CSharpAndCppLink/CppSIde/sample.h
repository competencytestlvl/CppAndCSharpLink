#pragma once
class Sample {
	int x;
public:
	Sample(int x);
	int add(int x);
	int multiply(int x);
};

// Helper methods for constructor and other method
extern "C" _declspec(dllexport) void* Instantiate(int x) {
	return (void*) new Sample(x);
}

extern "C" _declspec(dllexport) int Add(Sample* t, int y) {
	return t->add(y);
}

extern "C" _declspec(dllexport) int Multiply(Sample * t, int y) {
	return t->multiply(y);
}