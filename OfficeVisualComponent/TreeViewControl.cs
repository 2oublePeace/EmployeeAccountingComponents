using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OfficeVisualComponent
{
	public partial class TreeViewControl : UserControl
	{
		List<string> hierarchy;

		public int SelectedIndex
		{
			get
			{
				if(treeView.SelectedNode != null)
				{
					return treeView.SelectedNode.Index;
				}
				return 0;
			}
			set
			{
				if (value < 0)
				{
					treeView.SelectedNode = null;
					return;
				}
				if (value < treeView.Nodes.Count)
				{
					treeView.SelectedNode = treeView.Nodes[value];
				}
			}
		}

		public string GetSelectedValue()
		{
			if (treeView.SelectedNode.Nodes.Count == 0)
			{
				return treeView.SelectedNode.Text;
			}
			else
			{
				return null;
			}
		}

		public TreeViewControl()
		{
			InitializeComponent();
		}

		public void SetHierarchy(List<string> hierarchy)
		{
			this.hierarchy = hierarchy;
		}

		public void Add<T>(T obj) 
		{
			int levelCount = 0;
			bool addNewNode = true;
			TreeNodeCollection nodes = treeView.Nodes;
			Type type = typeof(T);
			FieldInfo[] fields = type.GetFields();
			PropertyInfo[] properties = type.GetProperties();

			foreach (var level in hierarchy)
			{
				foreach (var property in properties)
				{
					if(property.Name == level)
					{
						if(levelCount > 0)
						{
							nodes = nodes[nodes.Count - 1].Nodes;
						}

						foreach(TreeNode node in nodes)
						{
							if(node.Text == property.GetValue(obj).ToString() && property.Name != "fullName")
							{
								addNewNode = false;
							}
						}

						if(addNewNode)
						{
							nodes.Add(new TreeNode(property.GetValue(obj).ToString()));
						}

						addNewNode = true;
						break;
					}
				}
				levelCount++;
			}
		}
	}
}
