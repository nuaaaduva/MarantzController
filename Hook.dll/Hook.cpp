// Hook.dll.cpp : 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"
//#include "winnt.h"

#define WM_MYMSG  (WM_USER + 101)
HWND keyMsgHwnd = NULL;
HWND mouseMsgHwnd = NULL;

HHOOK keyHookId = NULL;
HHOOK mouseHookId = NULL;

tagMSLLHOOKSTRUCT mouseData;


LRESULT CALLBACK MouseProc(          //鼠标钩子的过程函数
	int nCode,
	WPARAM wParam,
	LPARAM lParam)
{
	if (wParam != WM_MOUSEMOVE)
	{
		mouseData = *(tagMSLLHOOKSTRUCT*)(lParam);
		PostMessage(mouseMsgHwnd, WM_MYMSG, wParam, (LPARAM)&mouseData);
	}

	return CallNextHookEx(mouseHookId, nCode, wParam, lParam);
}

LRESULT CALLBACK KeyBoardProc(       //键盘钩子的过程函数
	int nCode,
	WPARAM wParam,
	LPARAM lParam)
{
	PostMessage(keyMsgHwnd, WM_MYMSG, wParam, lParam);
	return CallNextHookEx(keyHookId, nCode, wParam, lParam);
}


EXTERN_C LRESULT HookKeyBoard(HWND handle)
{
	if (keyHookId) return -1;
	keyHookId = SetWindowsHookEx(WH_KEYBOARD_LL, KeyBoardProc, GetModuleHandle(L"HOOK"), 0);
	if (keyHookId)
	{
		keyMsgHwnd = handle;
		return WN_SUCCESS;
	}
	else
	{
		return GetLastError();
	}
}

EXTERN_C LRESULT HookMouse(HWND handle)
{
	if (mouseHookId) return -1;
	mouseHookId = SetWindowsHookEx(WH_MOUSE_LL, MouseProc, GetModuleHandle(L"HOOK"), 0);
	if (mouseHookId)
	{
		mouseMsgHwnd = handle;
		return WN_SUCCESS;
	}
	else
	{
		return GetLastError();
	}
}

EXTERN_C LRESULT UnHook()
{
	if(keyHookId) UnhookWindowsHookEx(keyHookId);
	if (mouseHookId) UnhookWindowsHookEx(mouseHookId);
	return WN_SUCCESS; 
}