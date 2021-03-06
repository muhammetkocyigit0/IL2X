﻿using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace IL2X.Core
{
	static class Utils
	{
		public static void DisposeInstances<T>(ref IEnumerable<T> instances) where T : class, IDisposable
		{
			if (instances != null)
			{
				foreach (var instance in instances)
				{
					instance.Dispose();
				}

				instances = null;
			}
		}

		public static void DisposeInstance<T>(ref T instance) where T : class, IDisposable
		{
			if (instance != null)
			{
				instance.Dispose();
				instance = null;
			}
		}

		public static bool Contains(this StringBuilder _this, char value)
		{
			for (int i = 0; i != _this.Length; ++i)
			{
				if (_this[i] == value) return true;
			}

			return false;
		}

		public static string GetAssemblyInfoVersion()
		{
			return Assembly.GetCallingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
		}

		public static string ReplaceNonWordChars(string value, char replacmentChar)
		{
			var newValue = new StringBuilder();
			foreach (char c in value)
			{
				if (!char.IsLetterOrDigit(c)) newValue.Append(replacmentChar);
				else newValue.Append(c);
			}

			return newValue.ToString();
		}

		public static bool HasAnyCodes(this OpCode opCode, params Code[] codes)
		{
			foreach (var code in codes)
			{
				if (opCode.Code == code) return true;
			}

			return false;
		}
	}
}
