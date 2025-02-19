﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Runtime;
using Mosa.Runtime.Plug;

namespace Mosa.Kernel.BareMetal.ARMv8A32;

public static class PlatformPlug
{
	private const uint BootReservedAddress = 0x00007E00; // Size=Undefined
	private const uint InitialGCMemoryPoolAddress = 0x03000000;  // @ 48MB
	private const uint InitialGCMemoryPoolSize = 16 * 1024 * 1024;  // [Size=16MB]

	[Plug("Mosa.Kernel.BareMetal.Platform::GetPageShift")]
	public static uint GetPageShift()
	{
		return 12;
	}

	[Plug("Mosa.Kernel.BareMetal.Platform::EntryPoint")]
	public static void EntryPoint()
	{
	}

	[Plug("Mosa.Kernel.BareMetal.Platform::GetBootReservedRegion")]
	public static AddressRange GetBootReservedRegion()
	{
		return new AddressRange(BootReservedAddress, Page.Size);
	}

	[Plug("Mosa.Kernel.BareMetal.Platform::GetInitialGCMemoryPool")]
	public static AddressRange GetInitialGCMemoryPool()
	{
		return new AddressRange(InitialGCMemoryPoolAddress, InitialGCMemoryPoolSize);
	}

	[Plug("Mosa.Kernel.BareMetal.Platform::PageTableSetup")]
	public static void PageTableSetup()
	{
		PageTable.Setup();
	}

	[Plug("Mosa.Kernel.BareMetal.Platform::PageTableInitialize")]
	public static void PageTableInitialize()
	{
	}

	[Plug("Mosa.Kernel.BareMetal.Platform::PageTableEnable")]
	public static void PageTableEnable()
	{
	}

	[Plug("Mosa.Kernel.BareMetal.Platform::PageTableMapVirtualAddressToPhysical")]
	public static void PageTableMapVirtualAddressToPhysical(uint virtualAddress, uint physicalAddress, bool present = true)
	{
		PageTable.MapVirtualAddressToPhysical(virtualAddress, physicalAddress, present);
	}

	[Plug("Mosa.Kernel.BareMetal.Platform::PageTableGetPhysicalAddressFromVirtual")]
	public static Pointer PageTableGetPhysicalAddressFromVirtual(Pointer virtualAddress)
	{
		return PageTable.GetPhysicalAddressFromVirtual(virtualAddress);
	}

	[Plug("Mosa.Kernel.BareMetal.Platform::ConsoleWrite")]
	public static void ConsoleWrite(byte c)
	{
	}
}
