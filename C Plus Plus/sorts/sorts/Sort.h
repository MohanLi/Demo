#ifndef __SORT_H__
#define __SORT_H__


class Sort
{
public:
	void swap(int &a, int &b);

	// ð������
	void bubbleSort(int array[], int length);
	// ѡ������
	void selectedSort(int array[], int length);
	// ��������
	void insertSort(int array[], int length);
};

#endif