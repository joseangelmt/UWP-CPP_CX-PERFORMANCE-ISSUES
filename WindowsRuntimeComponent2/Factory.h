#pragma once

namespace WindowsRuntimeComponent2
{
    public ref class Factory sealed
    {
    public:
		static WindowsRuntimeComponent1::Class1^ CreateObject();
		static WindowsRuntimeComponent1::Class1^ CreateNullObject();
	};
}
