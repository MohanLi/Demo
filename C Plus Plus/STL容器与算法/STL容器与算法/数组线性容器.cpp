#include <iostream>
#include <vector> // 容器
#include <algorithm> // 算法
#include <array> // 数组

using namespace std;
/*
	array 和 vector使用场合：
	array:不需要变长，容量较小
	vecto:需要变长，容量较大
*/

// 实现一个类模板，专门实现打印功能
template<class T>
class VectorPrint
{
public:
	void operator ()( T &t) // 重载()，使用()打印
	{
		cout << t << endl;
	}
};

void main1()
{
	// 动态数组，在堆上
	vector<int> myvector;
	myvector.push_back(1);
	myvector.push_back(11);
	myvector.push_back(31);
	myvector.push_back(21);

	// 数组， 静态数组，在栈上
	array<int, 10> myarray = {10, 9, 8, 7, 6, 5, 4, 3, 2, 1};

	VectorPrint<int> print;
	for_each (myvector.begin(), myvector.end(), print);
	for_each(myarray.begin(), myarray.end(), print);

	cin.get();
}