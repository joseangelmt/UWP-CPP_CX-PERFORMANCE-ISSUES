#include "pch.h"
#include "Factory.h"

using namespace WindowsRuntimeComponent2;
using namespace Platform;

WindowsRuntimeComponent1::Class1^ Factory::CreateObject()
{
	return ref new WindowsRuntimeComponent1::Class1();
}
