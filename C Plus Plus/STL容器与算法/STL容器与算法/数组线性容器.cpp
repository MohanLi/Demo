#include <iostream>
#include <vector> // ����
#include <algorithm> // �㷨
#include <array> // ����

using namespace std;
/*
	array �� vectorʹ�ó��ϣ�
	array:����Ҫ�䳤��������С
	vecto:��Ҫ�䳤�������ϴ�
*/

// ʵ��һ����ģ�壬ר��ʵ�ִ�ӡ����
template<class T>
class VectorPrint
{
public:
	void operator ()( T &t) // ����()��ʹ��()��ӡ
	{
		cout << t << endl;
	}
};

void main1()
{
	// ��̬���飬�ڶ���
	vector<int> myvector;
	myvector.push_back(1);
	myvector.push_back(11);
	myvector.push_back(31);
	myvector.push_back(21);

	// ���飬 ��̬���飬��ջ��
	array<int, 10> myarray = {10, 9, 8, 7, 6, 5, 4, 3, 2, 1};

	VectorPrint<int> print;
	for_each (myvector.begin(), myvector.end(), print);
	for_each(myarray.begin(), myarray.end(), print);

	cin.get();
}