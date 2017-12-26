#pragma once

#pragma optimize( "", off )


#include <iostream>

using namespace std;

#define SafeDeleteObj(obj) \
{\
if (obj)\
{\
	delete obj; \
	obj = NULL; \
}\
}

#define SafeDeleteArray(array) \
{\
if (array)\
{\
	delete[]array; \
	array = NULL; \
}\
};


#define SafeCloseFile(file)\
{\
if (file)\
{\
	fflush(file); \
	fclose(file); \
	file = NULL; \
}\
};
#define EXEC_STATIC_PREPARE \
	long exec_static_start = GetTickCount(); \
	int exec_static_count = 0; \
	long exec_static_sum = 0

#define EXEC_STATIC_BEGIN \
	exec_static_start = GetTickCount()

#define EXEC_STATIC_END(static_name,static_fire_count) \
	exec_static_count += 1; exec_static_sum += GetTickCount() - exec_static_start; \
if (exec_static_count == static_fire_count) { LOG_INFO(_T("%hs equal execute time:%ld ms in %d actions"), static_name, exec_static_sum / static_fire_count, static_fire_count); exec_static_count = 0; exec_static_sum = 0; }



#define  LIST_SORT_ASC(l) { l.sort(); }
#define  LIST_SORT_DESC(l) {l.sort(); l.reverse();}
