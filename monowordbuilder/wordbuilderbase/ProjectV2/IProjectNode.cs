//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4200
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Whee.WordBuilder.ProjectV2
{
	public interface IProjectNode
	{
        IProjectSerializer Serializer { get; }
		int Index { get; set; }
        int Length { get; set; }
		ProjectNodeType NodeType { get; }
		List<IProjectNode> Children { get; }
	}
}
