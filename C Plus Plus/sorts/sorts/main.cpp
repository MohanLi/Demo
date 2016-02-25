#include <iostream>
#include "Sort.h"

using namespace std;

void test()
{
	int array[10] = {15, 12, 0, 45, 78, 3, 44, 99, 65, 20};
/*
	for (int i = 0; i < 10; i++)
	{
		array[i] = rand() % 1000;
	}*/

	Sort *sort = new Sort;
	sort->insertSort(array, sizeof(array)/sizeof(*array));

	for (auto data : array)
	{
		cout << data << " ";
	}
}

int main()
{
	test();

	system("pause");
	return 0;
}