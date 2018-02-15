﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.


// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Xunit;
using Xunit.Extensions;

namespace Mosa.UnitTest.Collection.xUnit
{
	public class Fixture_ComparisoneEqualU1 : TestFixture
	{
		[Theory]
		[MemberData(nameof(U1U1))]
		public void CompareEqualU1(byte a, byte b)
		{
			Assert.Equal(ComparisonTests.CompareEqualU1(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareEqualU1", a, b));
		}
	}

	public class Fixture_ComparisoneNotEqualU1 : TestFixture
	{
		[Theory]
		[MemberData(nameof(U1U1))]
		public void CompareNotEqualU1(byte a, byte b)
		{
			Assert.Equal(ComparisonTests.CompareNotEqualU1(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareNotEqualU1", a, b));
		}
	}

	public class Fixture_ComparisoneGreaterThanU1 : TestFixture
	{
		[Theory]
		[MemberData(nameof(U1U1))]
		public void CompareGreaterThanU1(byte a, byte b)
		{
			Assert.Equal(ComparisonTests.CompareGreaterThanU1(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareGreaterThanU1", a, b));
		}
	}

	public class Fixture_ComparisoneLessThanU1 : TestFixture
	{
		[Theory]
		[MemberData(nameof(U1U1))]
		public void CompareLessThanU1(byte a, byte b)
		{
			Assert.Equal(ComparisonTests.CompareLessThanU1(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareLessThanU1", a, b));
		}
	}

	public class Fixture_ComparisoneGreaterThanOrEqualU1 : TestFixture
	{
		[Theory]
		[MemberData(nameof(U1U1))]
		public void CompareGreaterThanOrEqualU1(byte a, byte b)
		{
			Assert.Equal(ComparisonTests.CompareGreaterThanOrEqualU1(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareGreaterThanOrEqualU1", a, b));
		}
	}

	public class Fixture_ComparisoneLessThanOrEqualU1 : TestFixture
	{
		[Theory]
		[MemberData(nameof(U1U1))]
		public void CompareLessThanOrEqualU1(byte a, byte b)
		{
			Assert.Equal(ComparisonTests.CompareLessThanOrEqualU1(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareLessThanOrEqualU1", a, b));
		}
	}

	public class Fixture_ComparisoneEqualU2 : TestFixture
	{
		[Theory]
		[MemberData(nameof(U2U2))]
		public void CompareEqualU2(ushort a, ushort b)
		{
			Assert.Equal(ComparisonTests.CompareEqualU2(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareEqualU2", a, b));
		}
	}

	public class Fixture_ComparisoneNotEqualU2 : TestFixture
	{
		[Theory]
		[MemberData(nameof(U2U2))]
		public void CompareNotEqualU2(ushort a, ushort b)
		{
			Assert.Equal(ComparisonTests.CompareNotEqualU2(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareNotEqualU2", a, b));
		}
	}

	public class Fixture_ComparisoneGreaterThanU2 : TestFixture
	{
		[Theory]
		[MemberData(nameof(U2U2))]
		public void CompareGreaterThanU2(ushort a, ushort b)
		{
			Assert.Equal(ComparisonTests.CompareGreaterThanU2(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareGreaterThanU2", a, b));
		}
	}

	public class Fixture_ComparisoneLessThanU2 : TestFixture
	{
		[Theory]
		[MemberData(nameof(U2U2))]
		public void CompareLessThanU2(ushort a, ushort b)
		{
			Assert.Equal(ComparisonTests.CompareLessThanU2(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareLessThanU2", a, b));
		}
	}

	public class Fixture_ComparisoneGreaterThanOrEqualU2 : TestFixture
	{
		[Theory]
		[MemberData(nameof(U2U2))]
		public void CompareGreaterThanOrEqualU2(ushort a, ushort b)
		{
			Assert.Equal(ComparisonTests.CompareGreaterThanOrEqualU2(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareGreaterThanOrEqualU2", a, b));
		}
	}

	public class Fixture_ComparisoneLessThanOrEqualU2 : TestFixture
	{
		[Theory]
		[MemberData(nameof(U2U2))]
		public void CompareLessThanOrEqualU2(ushort a, ushort b)
		{
			Assert.Equal(ComparisonTests.CompareLessThanOrEqualU2(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareLessThanOrEqualU2", a, b));
		}
	}

	public class Fixture_ComparisoneEqualU4 : TestFixture
	{
		[Theory]
		[MemberData(nameof(U4U4))]
		public void CompareEqualU4(uint a, uint b)
		{
			Assert.Equal(ComparisonTests.CompareEqualU4(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareEqualU4", a, b));
		}
	}

	public class Fixture_ComparisoneNotEqualU4 : TestFixture
	{
		[Theory]
		[MemberData(nameof(U4U4))]
		public void CompareNotEqualU4(uint a, uint b)
		{
			Assert.Equal(ComparisonTests.CompareNotEqualU4(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareNotEqualU4", a, b));
		}
	}

	public class Fixture_ComparisoneGreaterThanU4 : TestFixture
	{
		[Theory]
		[MemberData(nameof(U4U4))]
		public void CompareGreaterThanU4(uint a, uint b)
		{
			Assert.Equal(ComparisonTests.CompareGreaterThanU4(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareGreaterThanU4", a, b));
		}
	}

	public class Fixture_ComparisoneLessThanU4 : TestFixture
	{
		[Theory]
		[MemberData(nameof(U4U4))]
		public void CompareLessThanU4(uint a, uint b)
		{
			Assert.Equal(ComparisonTests.CompareLessThanU4(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareLessThanU4", a, b));
		}
	}

	public class Fixture_ComparisoneGreaterThanOrEqualU4 : TestFixture
	{
		[Theory]
		[MemberData(nameof(U4U4))]
		public void CompareGreaterThanOrEqualU4(uint a, uint b)
		{
			Assert.Equal(ComparisonTests.CompareGreaterThanOrEqualU4(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareGreaterThanOrEqualU4", a, b));
		}
	}

	public class Fixture_ComparisoneLessThanOrEqualU4 : TestFixture
	{
		[Theory]
		[MemberData(nameof(U4U4))]
		public void CompareLessThanOrEqualU4(uint a, uint b)
		{
			Assert.Equal(ComparisonTests.CompareLessThanOrEqualU4(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareLessThanOrEqualU4", a, b));
		}
	}

	public class Fixture_ComparisoneEqualU8 : TestFixture
	{
		[Theory]
		[MemberData(nameof(U8U8))]
		public void CompareEqualU8(ulong a, ulong b)
		{
			Assert.Equal(ComparisonTests.CompareEqualU8(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareEqualU8", a, b));
		}
	}

	public class Fixture_ComparisoneNotEqualU8 : TestFixture
	{
		[Theory]
		[MemberData(nameof(U8U8))]
		public void CompareNotEqualU8(ulong a, ulong b)
		{
			Assert.Equal(ComparisonTests.CompareNotEqualU8(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareNotEqualU8", a, b));
		}
	}

	public class Fixture_ComparisoneGreaterThanU8 : TestFixture
	{
		[Theory]
		[MemberData(nameof(U8U8))]
		public void CompareGreaterThanU8(ulong a, ulong b)
		{
			Assert.Equal(ComparisonTests.CompareGreaterThanU8(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareGreaterThanU8", a, b));
		}
	}

	public class Fixture_ComparisoneLessThanU8 : TestFixture
	{
		[Theory]
		[MemberData(nameof(U8U8))]
		public void CompareLessThanU8(ulong a, ulong b)
		{
			Assert.Equal(ComparisonTests.CompareLessThanU8(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareLessThanU8", a, b));
		}
	}

	public class Fixture_ComparisoneGreaterThanOrEqualU8 : TestFixture
	{
		[Theory]
		[MemberData(nameof(U8U8))]
		public void CompareGreaterThanOrEqualU8(ulong a, ulong b)
		{
			Assert.Equal(ComparisonTests.CompareGreaterThanOrEqualU8(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareGreaterThanOrEqualU8", a, b));
		}
	}

	public class Fixture_ComparisoneLessThanOrEqualU8 : TestFixture
	{
		[Theory]
		[MemberData(nameof(U8U8))]
		public void CompareLessThanOrEqualU8(ulong a, ulong b)
		{
			Assert.Equal(ComparisonTests.CompareLessThanOrEqualU8(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareLessThanOrEqualU8", a, b));
		}
	}

	public class Fixture_ComparisoneEqualI1 : TestFixture
	{
		[Theory]
		[MemberData(nameof(I1I1))]
		public void CompareEqualI1(sbyte a, sbyte b)
		{
			Assert.Equal(ComparisonTests.CompareEqualI1(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareEqualI1", a, b));
		}
	}

	public class Fixture_ComparisoneNotEqualI1 : TestFixture
	{
		[Theory]
		[MemberData(nameof(I1I1))]
		public void CompareNotEqualI1(sbyte a, sbyte b)
		{
			Assert.Equal(ComparisonTests.CompareNotEqualI1(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareNotEqualI1", a, b));
		}
	}

	public class Fixture_ComparisoneGreaterThanI1 : TestFixture
	{
		[Theory]
		[MemberData(nameof(I1I1))]
		public void CompareGreaterThanI1(sbyte a, sbyte b)
		{
			Assert.Equal(ComparisonTests.CompareGreaterThanI1(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareGreaterThanI1", a, b));
		}
	}

	public class Fixture_ComparisoneLessThanI1 : TestFixture
	{
		[Theory]
		[MemberData(nameof(I1I1))]
		public void CompareLessThanI1(sbyte a, sbyte b)
		{
			Assert.Equal(ComparisonTests.CompareLessThanI1(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareLessThanI1", a, b));
		}
	}

	public class Fixture_ComparisoneGreaterThanOrEqualI1 : TestFixture
	{
		[Theory]
		[MemberData(nameof(I1I1))]
		public void CompareGreaterThanOrEqualI1(sbyte a, sbyte b)
		{
			Assert.Equal(ComparisonTests.CompareGreaterThanOrEqualI1(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareGreaterThanOrEqualI1", a, b));
		}
	}

	public class Fixture_ComparisoneLessThanOrEqualI1 : TestFixture
	{
		[Theory]
		[MemberData(nameof(I1I1))]
		public void CompareLessThanOrEqualI1(sbyte a, sbyte b)
		{
			Assert.Equal(ComparisonTests.CompareLessThanOrEqualI1(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareLessThanOrEqualI1", a, b));
		}
	}

	public class Fixture_ComparisoneEqualI2 : TestFixture
	{
		[Theory]
		[MemberData(nameof(I2I2))]
		public void CompareEqualI2(short a, short b)
		{
			Assert.Equal(ComparisonTests.CompareEqualI2(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareEqualI2", a, b));
		}
	}

	public class Fixture_ComparisoneNotEqualI2 : TestFixture
	{
		[Theory]
		[MemberData(nameof(I2I2))]
		public void CompareNotEqualI2(short a, short b)
		{
			Assert.Equal(ComparisonTests.CompareNotEqualI2(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareNotEqualI2", a, b));
		}
	}

	public class Fixture_ComparisoneGreaterThanI2 : TestFixture
	{
		[Theory]
		[MemberData(nameof(I2I2))]
		public void CompareGreaterThanI2(short a, short b)
		{
			Assert.Equal(ComparisonTests.CompareGreaterThanI2(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareGreaterThanI2", a, b));
		}
	}

	public class Fixture_ComparisoneLessThanI2 : TestFixture
	{
		[Theory]
		[MemberData(nameof(I2I2))]
		public void CompareLessThanI2(short a, short b)
		{
			Assert.Equal(ComparisonTests.CompareLessThanI2(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareLessThanI2", a, b));
		}
	}

	public class Fixture_ComparisoneGreaterThanOrEqualI2 : TestFixture
	{
		[Theory]
		[MemberData(nameof(I2I2))]
		public void CompareGreaterThanOrEqualI2(short a, short b)
		{
			Assert.Equal(ComparisonTests.CompareGreaterThanOrEqualI2(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareGreaterThanOrEqualI2", a, b));
		}
	}

	public class Fixture_ComparisoneLessThanOrEqualI2 : TestFixture
	{
		[Theory]
		[MemberData(nameof(I2I2))]
		public void CompareLessThanOrEqualI2(short a, short b)
		{
			Assert.Equal(ComparisonTests.CompareLessThanOrEqualI2(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareLessThanOrEqualI2", a, b));
		}
	}

	public class Fixture_ComparisoneEqualI4 : TestFixture
	{
		[Theory]
		[MemberData(nameof(I4I4))]
		public void CompareEqualI4(int a, int b)
		{
			Assert.Equal(ComparisonTests.CompareEqualI4(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareEqualI4", a, b));
		}
	}

	public class Fixture_ComparisoneNotEqualI4 : TestFixture
	{
		[Theory]
		[MemberData(nameof(I4I4))]
		public void CompareNotEqualI4(int a, int b)
		{
			Assert.Equal(ComparisonTests.CompareNotEqualI4(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareNotEqualI4", a, b));
		}
	}

	public class Fixture_ComparisoneGreaterThanI4 : TestFixture
	{
		[Theory]
		[MemberData(nameof(I4I4))]
		public void CompareGreaterThanI4(int a, int b)
		{
			Assert.Equal(ComparisonTests.CompareGreaterThanI4(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareGreaterThanI4", a, b));
		}
	}

	public class Fixture_ComparisoneLessThanI4 : TestFixture
	{
		[Theory]
		[MemberData(nameof(I4I4))]
		public void CompareLessThanI4(int a, int b)
		{
			Assert.Equal(ComparisonTests.CompareLessThanI4(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareLessThanI4", a, b));
		}
	}

	public class Fixture_ComparisoneGreaterThanOrEqualI4 : TestFixture
	{
		[Theory]
		[MemberData(nameof(I4I4))]
		public void CompareGreaterThanOrEqualI4(int a, int b)
		{
			Assert.Equal(ComparisonTests.CompareGreaterThanOrEqualI4(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareGreaterThanOrEqualI4", a, b));
		}
	}

	public class Fixture_ComparisoneLessThanOrEqualI4 : TestFixture
	{
		[Theory]
		[MemberData(nameof(I4I4))]
		public void CompareLessThanOrEqualI4(int a, int b)
		{
			Assert.Equal(ComparisonTests.CompareLessThanOrEqualI4(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareLessThanOrEqualI4", a, b));
		}
	}

	public class Fixture_ComparisoneEqualI8 : TestFixture
	{
		[Theory]
		[MemberData(nameof(I8I8))]
		public void CompareEqualI8(long a, long b)
		{
			Assert.Equal(ComparisonTests.CompareEqualI8(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareEqualI8", a, b));
		}
	}

	public class Fixture_ComparisoneNotEqualI8 : TestFixture
	{
		[Theory]
		[MemberData(nameof(I8I8))]
		public void CompareNotEqualI8(long a, long b)
		{
			Assert.Equal(ComparisonTests.CompareNotEqualI8(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareNotEqualI8", a, b));
		}
	}

	public class Fixture_ComparisoneGreaterThanI8 : TestFixture
	{
		[Theory]
		[MemberData(nameof(I8I8))]
		public void CompareGreaterThanI8(long a, long b)
		{
			Assert.Equal(ComparisonTests.CompareGreaterThanI8(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareGreaterThanI8", a, b));
		}
	}

	public class Fixture_ComparisoneLessThanI8 : TestFixture
	{
		[Theory]
		[MemberData(nameof(I8I8))]
		public void CompareLessThanI8(long a, long b)
		{
			Assert.Equal(ComparisonTests.CompareLessThanI8(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareLessThanI8", a, b));
		}
	}

	public class Fixture_ComparisoneGreaterThanOrEqualI8 : TestFixture
	{
		[Theory]
		[MemberData(nameof(I8I8))]
		public void CompareGreaterThanOrEqualI8(long a, long b)
		{
			Assert.Equal(ComparisonTests.CompareGreaterThanOrEqualI8(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareGreaterThanOrEqualI8", a, b));
		}
	}

	public class Fixture_ComparisoneLessThanOrEqualI8 : TestFixture
	{
		[Theory]
		[MemberData(nameof(I8I8))]
		public void CompareLessThanOrEqualI8(long a, long b)
		{
			Assert.Equal(ComparisonTests.CompareLessThanOrEqualI8(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareLessThanOrEqualI8", a, b));
		}
	}

	public class Fixture_ComparisoneEqualC : TestFixture
	{
		[Theory]
		[MemberData(nameof(CC))]
		public void CompareEqualC(char a, char b)
		{
			Assert.Equal(ComparisonTests.CompareEqualC(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareEqualC", a, b));
		}
	}

	public class Fixture_ComparisoneNotEqualC : TestFixture
	{
		[Theory]
		[MemberData(nameof(CC))]
		public void CompareNotEqualC(char a, char b)
		{
			Assert.Equal(ComparisonTests.CompareNotEqualC(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareNotEqualC", a, b));
		}
	}

	public class Fixture_ComparisoneGreaterThanC : TestFixture
	{
		[Theory]
		[MemberData(nameof(CC))]
		public void CompareGreaterThanC(char a, char b)
		{
			Assert.Equal(ComparisonTests.CompareGreaterThanC(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareGreaterThanC", a, b));
		}
	}

	public class Fixture_ComparisoneLessThanC : TestFixture
	{
		[Theory]
		[MemberData(nameof(CC))]
		public void CompareLessThanC(char a, char b)
		{
			Assert.Equal(ComparisonTests.CompareLessThanC(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareLessThanC", a, b));
		}
	}

	public class Fixture_ComparisoneGreaterThanOrEqualC : TestFixture
	{
		[Theory]
		[MemberData(nameof(CC))]
		public void CompareGreaterThanOrEqualC(char a, char b)
		{
			Assert.Equal(ComparisonTests.CompareGreaterThanOrEqualC(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareGreaterThanOrEqualC", a, b));
		}
	}

	public class Fixture_ComparisoneLessThanOrEqualC : TestFixture
	{
		[Theory]
		[MemberData(nameof(CC))]
		public void CompareLessThanOrEqualC(char a, char b)
		{
			Assert.Equal(ComparisonTests.CompareLessThanOrEqualC(a, b), Run<bool>("Mosa.UnitTest.Collection.ComparisonTests.CompareLessThanOrEqualC", a, b));
		}
	}

}
