#include "Sort.h"
#include <iostream>

using namespace std;

void Sort::bubbleSort(int array[], int length)
{
	for (int i = 0; i < length; i++)
	{
		for (int j = 0; j < length - 1; j++)
		{
			if (array[j] > array[j + 1])
			{
				swap(array[j], array[j + 1]);
			}
		}
	}
}

void Sort::selectedSort(int array[], int length)
{
	for (int i = 0; i < length; i++)
	{
		for (int j = i; j < length; j++)
		{
			if (array[i] > array[j])
			{
				swap(array[i], array[j]);
			}
		}
	}
}

void Sort::insertSort(int array[], int length)
{
	for (int i = 0; i < length; i++)
	{
		for (int j = 0; j < i; j++)
		{
			if (array[i] < array[j])
			{
				swap(array[i], array[j]);
			}
		}
	}
}

void Sort::swap(int &a, int &b)
{
	a = a + b;
	b = a - b;
	a = a - b;
}