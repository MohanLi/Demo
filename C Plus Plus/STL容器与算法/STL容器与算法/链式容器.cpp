#include <iostream>
#include <list>

using namespace std;

// list ʹ�ó��ϣ�������ӡ�����ɾ��
void  main()
{
	list<int> mylist;
	mylist.push_back(15);
	mylist.push_back(31);
	mylist.push_back(21);
	mylist.push_back(11);
	//mylist[1] // ����ķ��ʷ�ʽ

	auto ibegin = mylist.begin();
	auto iend = mylist.end();
	for (; ibegin != iend; ibegin++)
	{
		cout << *ibegin << endl;
	}

	cin.get();
}