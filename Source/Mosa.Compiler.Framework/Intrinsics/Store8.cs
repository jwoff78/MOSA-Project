﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

namespace Mosa.Compiler.Framework.Intrinsics;

/// <summary>
/// IntrinsicMethods
/// </summary>
internal static partial class IntrinsicMethods
{
	[IntrinsicMethod("Mosa.Runtime.Intrinsic::Store8")]
	private static void Store8(Context context, TransformContext transformContext)
	{
		var instruction = IRInstruction.Store8;

		var operand1 = context.Operand1;
		var operand2 = context.OperandCount == 3 ? context.Operand2 : transformContext.ConstantZero;
		var operand3 = context.OperandCount == 3 ? context.Operand3 : context.Operand2;

		LoadStore.Set(context, transformContext, instruction, null, operand1, operand2, operand3);
	}
}
