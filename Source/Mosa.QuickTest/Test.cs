﻿/*
 * (c) 2008 MOSA - The Managed Operating System Alliance
 *
 * Licensed under the terms of the New BSD License.
 *
 */

using System;

namespace Mosa.HelloWorld.Tests
{
	public interface GenericInterface<T>
	{
		int Return10();
	}

	public class GenericTest<T> : GenericInterface<T>
	{
		public T value;

		public T GetValue() { return value; }
		public void SetValue(T value) { this.value = value; }

		public int Return10() { return 10; }
	}

	public class Test
	{
		public static void GoTest()
		{
			GenericTest1();
			GenericTest2();
			GenericTest3();
			GenericTest4();
		}

		public static bool GenericTest1()
		{
			GenericTest<int> genericObject = new GenericTest<int>();

			genericObject.value = 10;

			return genericObject.value == 10;
		}

		public static bool GenericTest2()
		{
			GenericTest<object> genericObject = new GenericTest<object>();

			genericObject.value = new object();

			return true;
		}

		public static bool GenericTest3()
		{
			GenericTest<int> genericObject = new GenericTest<int>();

			genericObject.value = 10;

			return genericObject.GetValue() == 10;
		}

		public static bool GenericTest4()
		{
			GenericTest<int> genericObject = new GenericTest<int>();

			return (genericObject.Return10() != 10);
		}
	}

}
