#include <iostream>
#include <list>

using namespace std;

// list 使用场合：经常添加、经常删除
void  main()
{
	list<int> mylist;
	mylist.push_back(15);
	mylist.push_back(31);
	mylist.push_back(21);
	mylist.push_back(11);
	//mylist[1] // 错误的访问方式

	auto ibegin = mylist.begin();
	auto iend = mylist.end();
	for (; ibegin != iend; ibegin++)
	{
		cout << *ibegin << endl;
	}

	cin.get();
}