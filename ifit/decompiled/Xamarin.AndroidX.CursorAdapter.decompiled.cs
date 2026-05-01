using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using Android;
using Android.Content;
using Android.Database;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Interop;
using Java.Lang;
using Microsoft.CodeAnalysis;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyMetadata("BUILD_COMMIT", "791ebe2cb9b9b044bb1d30e9bd4c6097326f4bbe")]
[assembly: AssemblyMetadata("BUILD_NUMBER", "20230120.4")]
[assembly: AssemblyMetadata("BUILD_TIMESTAMP", "1/20/2023 8:31:40 PM")]
[assembly: LinkerSafe]
[assembly: AssemblyMetadata("IsTrimmable", "True")]
[assembly: NamespaceMapping(Java = "androidx.cursoradapter.widget", Managed = "AndroidX.CursorAdapter.Widget")]
[assembly: TargetFramework("MonoAndroid,Version=v12.0", FrameworkDisplayName = "Xamarin.Android v12.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription(".NET for Android (formerly Xamarin.Android) bindings for AndroidX library 'androidx.cursoradapter:cursoradapter'.")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.AndroidX.CursorAdapter")]
[assembly: AssemblyTitle("Xamarin.AndroidX.CursorAdapter")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/xamarin/AndroidX.git")]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
namespace Microsoft.CodeAnalysis
{
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
	internal sealed class EmbeddedAttribute : Attribute
	{
	}
}
namespace System.Runtime.CompilerServices
{
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter, AllowMultiple = false, Inherited = false)]
	internal sealed class NullableAttribute : Attribute
	{
		public readonly byte[] NullableFlags;

		public NullableAttribute(byte P_0)
		{
			NullableFlags = new byte[1] { P_0 };
		}
	}
}
internal delegate int _JniMarshal_PP_I(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PP_V(IntPtr jnienv, IntPtr klass);
internal delegate long _JniMarshal_PPI_J(IntPtr jnienv, IntPtr klass, int p0);
internal delegate IntPtr _JniMarshal_PPI_L(IntPtr jnienv, IntPtr klass, int p0);
internal delegate IntPtr _JniMarshal_PPILL_L(IntPtr jnienv, IntPtr klass, int p0, IntPtr p1, IntPtr p2);
internal delegate IntPtr _JniMarshal_PPL_L(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate IntPtr _JniMarshal_PPLLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2);
internal delegate void _JniMarshal_PPLLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2);
internal delegate void _JniMarshal_PPLLZ_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, bool p2);
namespace AndroidX.CursorAdapter.Widget
{
	[Register("androidx/cursoradapter/widget/CursorAdapter", DoNotGenerateAcw = true)]
	public abstract class CursorAdapter : BaseAdapter, IFilterable, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/cursoradapter/widget/CursorAdapter", typeof(CursorAdapter));

		private static Delegate cb_getCount;

		private static Delegate cb_getCursor;

		private static Delegate cb_getFilter;

		private static Delegate cb_getFilterQueryProvider;

		private static Delegate cb_setFilterQueryProvider_Landroid_widget_FilterQueryProvider_;

		private static Delegate cb_bindView_Landroid_view_View_Landroid_content_Context_Landroid_database_Cursor_;

		private static Delegate cb_changeCursor_Landroid_database_Cursor_;

		private static Delegate cb_convertToString_Landroid_database_Cursor_;

		private static Delegate cb_getItem_I;

		private static Delegate cb_getItemId_I;

		private static Delegate cb_getView_ILandroid_view_View_Landroid_view_ViewGroup_;

		private static Delegate cb_init_Landroid_content_Context_Landroid_database_Cursor_Z;

		private static Delegate cb_newDropDownView_Landroid_content_Context_Landroid_database_Cursor_Landroid_view_ViewGroup_;

		private static Delegate cb_newView_Landroid_content_Context_Landroid_database_Cursor_Landroid_view_ViewGroup_;

		private static Delegate cb_onContentChanged;

		private static Delegate cb_runQueryOnBackgroundThread_Ljava_lang_CharSequence_;

		private static Delegate cb_swapCursor_Landroid_database_Cursor_;

		[Register("mAutoRequery")]
		protected bool MAutoRequery
		{
			get
			{
				return _members.InstanceFields.GetBooleanValue("mAutoRequery.Z", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mAutoRequery.Z", this, value);
			}
		}

		[Register("mContext")]
		protected Context MContext
		{
			get
			{
				return Java.Lang.Object.GetObject<Context>(_members.InstanceFields.GetObjectValue("mContext.Landroid/content/Context;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mContext.Landroid/content/Context;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("mCursor")]
		protected ICursor MCursor
		{
			get
			{
				return Java.Lang.Object.GetObject<ICursor>(_members.InstanceFields.GetObjectValue("mCursor.Landroid/database/Cursor;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mCursor.Landroid/database/Cursor;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("mDataSetObserver")]
		protected DataSetObserver MDataSetObserver
		{
			get
			{
				return Java.Lang.Object.GetObject<DataSetObserver>(_members.InstanceFields.GetObjectValue("mDataSetObserver.Landroid/database/DataSetObserver;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mDataSetObserver.Landroid/database/DataSetObserver;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("mDataValid")]
		protected bool MDataValid
		{
			get
			{
				return _members.InstanceFields.GetBooleanValue("mDataValid.Z", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mDataValid.Z", this, value);
			}
		}

		[Register("mFilterQueryProvider")]
		protected IFilterQueryProvider MFilterQueryProvider
		{
			get
			{
				return Java.Lang.Object.GetObject<IFilterQueryProvider>(_members.InstanceFields.GetObjectValue("mFilterQueryProvider.Landroid/widget/FilterQueryProvider;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mFilterQueryProvider.Landroid/widget/FilterQueryProvider;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("mRowIDColumn")]
		protected int MRowIDColumn
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mRowIDColumn.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mRowIDColumn.I", this, value);
			}
		}

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override int Count
		{
			[Register("getCount", "()I", "GetGetCountHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getCount.()I", this, null);
			}
		}

		public unsafe virtual ICursor Cursor
		{
			[Register("getCursor", "()Landroid/database/Cursor;", "GetGetCursorHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ICursor>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCursor.()Landroid/database/Cursor;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual Filter Filter
		{
			[Register("getFilter", "()Landroid/widget/Filter;", "GetGetFilterHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Filter>(_members.InstanceMethods.InvokeVirtualObjectMethod("getFilter.()Landroid/widget/Filter;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual IFilterQueryProvider FilterQueryProvider
		{
			[Register("getFilterQueryProvider", "()Landroid/widget/FilterQueryProvider;", "GetGetFilterQueryProviderHandler")]
			get
			{
				return Java.Lang.Object.GetObject<IFilterQueryProvider>(_members.InstanceMethods.InvokeVirtualObjectMethod("getFilterQueryProvider.()Landroid/widget/FilterQueryProvider;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setFilterQueryProvider", "(Landroid/widget/FilterQueryProvider;)V", "GetSetFilterQueryProvider_Landroid_widget_FilterQueryProvider_Handler")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setFilterQueryProvider.(Landroid/widget/FilterQueryProvider;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		protected CursorAdapter(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/database/Cursor;)V", "")]
		public unsafe CursorAdapter(Context context, ICursor c)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((c == null) ? IntPtr.Zero : ((Java.Lang.Object)c).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/database/Cursor;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/database/Cursor;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(c);
			}
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/database/Cursor;Z)V", "")]
		public unsafe CursorAdapter(Context context, ICursor c, bool autoRequery)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((c == null) ? IntPtr.Zero : ((Java.Lang.Object)c).Handle);
				ptr[2] = new JniArgumentValue(autoRequery);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/database/Cursor;Z)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/database/Cursor;Z)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(c);
			}
		}

		[Register(".ctor", "(Landroid/content/Context;Landroid/database/Cursor;I)V", "")]
		public unsafe CursorAdapter(Context context, ICursor c, int flags)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((c == null) ? IntPtr.Zero : ((Java.Lang.Object)c).Handle);
				ptr[2] = new JniArgumentValue(flags);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/database/Cursor;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/database/Cursor;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(c);
			}
		}

		private static Delegate GetGetCountHandler()
		{
			if ((object)cb_getCount == null)
			{
				cb_getCount = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetCount));
			}
			return cb_getCount;
		}

		private static int n_GetCount(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<CursorAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Count;
		}

		private static Delegate GetGetCursorHandler()
		{
			if ((object)cb_getCursor == null)
			{
				cb_getCursor = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCursor));
			}
			return cb_getCursor;
		}

		private static IntPtr n_GetCursor(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CursorAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Cursor);
		}

		private static Delegate GetGetFilterHandler()
		{
			if ((object)cb_getFilter == null)
			{
				cb_getFilter = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetFilter));
			}
			return cb_getFilter;
		}

		private static IntPtr n_GetFilter(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CursorAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Filter);
		}

		private static Delegate GetGetFilterQueryProviderHandler()
		{
			if ((object)cb_getFilterQueryProvider == null)
			{
				cb_getFilterQueryProvider = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetFilterQueryProvider));
			}
			return cb_getFilterQueryProvider;
		}

		private static IntPtr n_GetFilterQueryProvider(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CursorAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FilterQueryProvider);
		}

		private static Delegate GetSetFilterQueryProvider_Landroid_widget_FilterQueryProvider_Handler()
		{
			if ((object)cb_setFilterQueryProvider_Landroid_widget_FilterQueryProvider_ == null)
			{
				cb_setFilterQueryProvider_Landroid_widget_FilterQueryProvider_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetFilterQueryProvider_Landroid_widget_FilterQueryProvider_));
			}
			return cb_setFilterQueryProvider_Landroid_widget_FilterQueryProvider_;
		}

		private static void n_SetFilterQueryProvider_Landroid_widget_FilterQueryProvider_(IntPtr jnienv, IntPtr native__this, IntPtr native_filterQueryProvider)
		{
			CursorAdapter cursorAdapter = Java.Lang.Object.GetObject<CursorAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IFilterQueryProvider filterQueryProvider = Java.Lang.Object.GetObject<IFilterQueryProvider>(native_filterQueryProvider, JniHandleOwnership.DoNotTransfer);
			cursorAdapter.FilterQueryProvider = filterQueryProvider;
		}

		private static Delegate GetBindView_Landroid_view_View_Landroid_content_Context_Landroid_database_Cursor_Handler()
		{
			if ((object)cb_bindView_Landroid_view_View_Landroid_content_Context_Landroid_database_Cursor_ == null)
			{
				cb_bindView_Landroid_view_View_Landroid_content_Context_Landroid_database_Cursor_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_BindView_Landroid_view_View_Landroid_content_Context_Landroid_database_Cursor_));
			}
			return cb_bindView_Landroid_view_View_Landroid_content_Context_Landroid_database_Cursor_;
		}

		private static void n_BindView_Landroid_view_View_Landroid_content_Context_Landroid_database_Cursor_(IntPtr jnienv, IntPtr native__this, IntPtr native_view, IntPtr native_context, IntPtr native_cursor)
		{
			CursorAdapter cursorAdapter = Java.Lang.Object.GetObject<CursorAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View view = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			ICursor cursor = Java.Lang.Object.GetObject<ICursor>(native_cursor, JniHandleOwnership.DoNotTransfer);
			cursorAdapter.BindView(view, context, cursor);
		}

		[Register("bindView", "(Landroid/view/View;Landroid/content/Context;Landroid/database/Cursor;)V", "GetBindView_Landroid_view_View_Landroid_content_Context_Landroid_database_Cursor_Handler")]
		public abstract void BindView(View view, Context context, ICursor cursor);

		private static Delegate GetChangeCursor_Landroid_database_Cursor_Handler()
		{
			if ((object)cb_changeCursor_Landroid_database_Cursor_ == null)
			{
				cb_changeCursor_Landroid_database_Cursor_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_ChangeCursor_Landroid_database_Cursor_));
			}
			return cb_changeCursor_Landroid_database_Cursor_;
		}

		private static void n_ChangeCursor_Landroid_database_Cursor_(IntPtr jnienv, IntPtr native__this, IntPtr native_cursor)
		{
			CursorAdapter cursorAdapter = Java.Lang.Object.GetObject<CursorAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICursor cursor = Java.Lang.Object.GetObject<ICursor>(native_cursor, JniHandleOwnership.DoNotTransfer);
			cursorAdapter.ChangeCursor(cursor);
		}

		[Register("changeCursor", "(Landroid/database/Cursor;)V", "GetChangeCursor_Landroid_database_Cursor_Handler")]
		public unsafe virtual void ChangeCursor(ICursor cursor)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((cursor == null) ? IntPtr.Zero : ((Java.Lang.Object)cursor).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("changeCursor.(Landroid/database/Cursor;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(cursor);
			}
		}

		private static Delegate GetConvertToString_Landroid_database_Cursor_Handler()
		{
			if ((object)cb_convertToString_Landroid_database_Cursor_ == null)
			{
				cb_convertToString_Landroid_database_Cursor_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_ConvertToString_Landroid_database_Cursor_));
			}
			return cb_convertToString_Landroid_database_Cursor_;
		}

		private static IntPtr n_ConvertToString_Landroid_database_Cursor_(IntPtr jnienv, IntPtr native__this, IntPtr native_cursor)
		{
			CursorAdapter cursorAdapter = Java.Lang.Object.GetObject<CursorAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICursor cursor = Java.Lang.Object.GetObject<ICursor>(native_cursor, JniHandleOwnership.DoNotTransfer);
			return CharSequence.ToLocalJniHandle(cursorAdapter.ConvertToStringFormatted(cursor));
		}

		[Register("convertToString", "(Landroid/database/Cursor;)Ljava/lang/CharSequence;", "GetConvertToString_Landroid_database_Cursor_Handler")]
		public unsafe virtual ICharSequence ConvertToStringFormatted(ICursor cursor)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((cursor == null) ? IntPtr.Zero : ((Java.Lang.Object)cursor).Handle);
				return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("convertToString.(Landroid/database/Cursor;)Ljava/lang/CharSequence;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(cursor);
			}
		}

		public string ConvertToString(ICursor cursor)
		{
			return ConvertToStringFormatted(cursor)?.ToString();
		}

		private static Delegate GetGetItem_IHandler()
		{
			if ((object)cb_getItem_I == null)
			{
				cb_getItem_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_GetItem_I));
			}
			return cb_getItem_I;
		}

		private static IntPtr n_GetItem_I(IntPtr jnienv, IntPtr native__this, int position)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CursorAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetItem(position));
		}

		[Register("getItem", "(I)Ljava/lang/Object;", "GetGetItem_IHandler")]
		public unsafe override Java.Lang.Object GetItem(int position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(position);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getItem.(I)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetGetItemId_IHandler()
		{
			if ((object)cb_getItemId_I == null)
			{
				cb_getItemId_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_J(n_GetItemId_I));
			}
			return cb_getItemId_I;
		}

		private static long n_GetItemId_I(IntPtr jnienv, IntPtr native__this, int position)
		{
			return Java.Lang.Object.GetObject<CursorAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetItemId(position);
		}

		[Register("getItemId", "(I)J", "GetGetItemId_IHandler")]
		public unsafe override long GetItemId(int position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(position);
			return _members.InstanceMethods.InvokeVirtualInt64Method("getItemId.(I)J", this, ptr);
		}

		private static Delegate GetGetView_ILandroid_view_View_Landroid_view_ViewGroup_Handler()
		{
			if ((object)cb_getView_ILandroid_view_View_Landroid_view_ViewGroup_ == null)
			{
				cb_getView_ILandroid_view_View_Landroid_view_ViewGroup_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPILL_L(n_GetView_ILandroid_view_View_Landroid_view_ViewGroup_));
			}
			return cb_getView_ILandroid_view_View_Landroid_view_ViewGroup_;
		}

		private static IntPtr n_GetView_ILandroid_view_View_Landroid_view_ViewGroup_(IntPtr jnienv, IntPtr native__this, int position, IntPtr native_convertView, IntPtr native_parent)
		{
			CursorAdapter cursorAdapter = Java.Lang.Object.GetObject<CursorAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View convertView = Java.Lang.Object.GetObject<View>(native_convertView, JniHandleOwnership.DoNotTransfer);
			ViewGroup parent = Java.Lang.Object.GetObject<ViewGroup>(native_parent, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(cursorAdapter.GetView(position, convertView, parent));
		}

		[Register("getView", "(ILandroid/view/View;Landroid/view/ViewGroup;)Landroid/view/View;", "GetGetView_ILandroid_view_View_Landroid_view_ViewGroup_Handler")]
		public unsafe override View GetView(int position, View convertView, ViewGroup parent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(position);
				ptr[1] = new JniArgumentValue(convertView?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("getView.(ILandroid/view/View;Landroid/view/ViewGroup;)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(convertView);
				GC.KeepAlive(parent);
			}
		}

		private static Delegate GetInit_Landroid_content_Context_Landroid_database_Cursor_ZHandler()
		{
			if ((object)cb_init_Landroid_content_Context_Landroid_database_Cursor_Z == null)
			{
				cb_init_Landroid_content_Context_Landroid_database_Cursor_Z = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLZ_V(n_Init_Landroid_content_Context_Landroid_database_Cursor_Z));
			}
			return cb_init_Landroid_content_Context_Landroid_database_Cursor_Z;
		}

		private static void n_Init_Landroid_content_Context_Landroid_database_Cursor_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_c, bool autoRequery)
		{
			CursorAdapter cursorAdapter = Java.Lang.Object.GetObject<CursorAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			ICursor c = Java.Lang.Object.GetObject<ICursor>(native_c, JniHandleOwnership.DoNotTransfer);
			cursorAdapter.Init(context, c, autoRequery);
		}

		[Register("init", "(Landroid/content/Context;Landroid/database/Cursor;Z)V", "GetInit_Landroid_content_Context_Landroid_database_Cursor_ZHandler")]
		protected unsafe virtual void Init(Context context, ICursor c, bool autoRequery)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((c == null) ? IntPtr.Zero : ((Java.Lang.Object)c).Handle);
				ptr[2] = new JniArgumentValue(autoRequery);
				_members.InstanceMethods.InvokeVirtualVoidMethod("init.(Landroid/content/Context;Landroid/database/Cursor;Z)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(c);
			}
		}

		private static Delegate GetNewDropDownView_Landroid_content_Context_Landroid_database_Cursor_Landroid_view_ViewGroup_Handler()
		{
			if ((object)cb_newDropDownView_Landroid_content_Context_Landroid_database_Cursor_Landroid_view_ViewGroup_ == null)
			{
				cb_newDropDownView_Landroid_content_Context_Landroid_database_Cursor_Landroid_view_ViewGroup_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_L(n_NewDropDownView_Landroid_content_Context_Landroid_database_Cursor_Landroid_view_ViewGroup_));
			}
			return cb_newDropDownView_Landroid_content_Context_Landroid_database_Cursor_Landroid_view_ViewGroup_;
		}

		private static IntPtr n_NewDropDownView_Landroid_content_Context_Landroid_database_Cursor_Landroid_view_ViewGroup_(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_cursor, IntPtr native_parent)
		{
			CursorAdapter cursorAdapter = Java.Lang.Object.GetObject<CursorAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			ICursor cursor = Java.Lang.Object.GetObject<ICursor>(native_cursor, JniHandleOwnership.DoNotTransfer);
			ViewGroup parent = Java.Lang.Object.GetObject<ViewGroup>(native_parent, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(cursorAdapter.NewDropDownView(context, cursor, parent));
		}

		[Register("newDropDownView", "(Landroid/content/Context;Landroid/database/Cursor;Landroid/view/ViewGroup;)Landroid/view/View;", "GetNewDropDownView_Landroid_content_Context_Landroid_database_Cursor_Landroid_view_ViewGroup_Handler")]
		public unsafe virtual View NewDropDownView(Context context, ICursor cursor, ViewGroup parent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((cursor == null) ? IntPtr.Zero : ((Java.Lang.Object)cursor).Handle);
				ptr[2] = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeVirtualObjectMethod("newDropDownView.(Landroid/content/Context;Landroid/database/Cursor;Landroid/view/ViewGroup;)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(cursor);
				GC.KeepAlive(parent);
			}
		}

		private static Delegate GetNewView_Landroid_content_Context_Landroid_database_Cursor_Landroid_view_ViewGroup_Handler()
		{
			if ((object)cb_newView_Landroid_content_Context_Landroid_database_Cursor_Landroid_view_ViewGroup_ == null)
			{
				cb_newView_Landroid_content_Context_Landroid_database_Cursor_Landroid_view_ViewGroup_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_L(n_NewView_Landroid_content_Context_Landroid_database_Cursor_Landroid_view_ViewGroup_));
			}
			return cb_newView_Landroid_content_Context_Landroid_database_Cursor_Landroid_view_ViewGroup_;
		}

		private static IntPtr n_NewView_Landroid_content_Context_Landroid_database_Cursor_Landroid_view_ViewGroup_(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_cursor, IntPtr native_parent)
		{
			CursorAdapter cursorAdapter = Java.Lang.Object.GetObject<CursorAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			ICursor cursor = Java.Lang.Object.GetObject<ICursor>(native_cursor, JniHandleOwnership.DoNotTransfer);
			ViewGroup parent = Java.Lang.Object.GetObject<ViewGroup>(native_parent, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(cursorAdapter.NewView(context, cursor, parent));
		}

		[Register("newView", "(Landroid/content/Context;Landroid/database/Cursor;Landroid/view/ViewGroup;)Landroid/view/View;", "GetNewView_Landroid_content_Context_Landroid_database_Cursor_Landroid_view_ViewGroup_Handler")]
		public abstract View NewView(Context context, ICursor cursor, ViewGroup parent);

		private static Delegate GetOnContentChangedHandler()
		{
			if ((object)cb_onContentChanged == null)
			{
				cb_onContentChanged = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnContentChanged));
			}
			return cb_onContentChanged;
		}

		private static void n_OnContentChanged(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<CursorAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnContentChanged();
		}

		[Register("onContentChanged", "()V", "GetOnContentChangedHandler")]
		protected unsafe virtual void OnContentChanged()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("onContentChanged.()V", this, null);
		}

		private static Delegate GetRunQueryOnBackgroundThread_Ljava_lang_CharSequence_Handler()
		{
			if ((object)cb_runQueryOnBackgroundThread_Ljava_lang_CharSequence_ == null)
			{
				cb_runQueryOnBackgroundThread_Ljava_lang_CharSequence_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_RunQueryOnBackgroundThread_Ljava_lang_CharSequence_));
			}
			return cb_runQueryOnBackgroundThread_Ljava_lang_CharSequence_;
		}

		private static IntPtr n_RunQueryOnBackgroundThread_Ljava_lang_CharSequence_(IntPtr jnienv, IntPtr native__this, IntPtr native_constraint)
		{
			CursorAdapter cursorAdapter = Java.Lang.Object.GetObject<CursorAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence constraint = Java.Lang.Object.GetObject<ICharSequence>(native_constraint, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(cursorAdapter.RunQueryOnBackgroundThread(constraint));
		}

		[Register("runQueryOnBackgroundThread", "(Ljava/lang/CharSequence;)Landroid/database/Cursor;", "GetRunQueryOnBackgroundThread_Ljava_lang_CharSequence_Handler")]
		public unsafe virtual ICursor RunQueryOnBackgroundThread(ICharSequence constraint)
		{
			IntPtr intPtr = CharSequence.ToLocalJniHandle(constraint);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ICursor>(_members.InstanceMethods.InvokeVirtualObjectMethod("runQueryOnBackgroundThread.(Ljava/lang/CharSequence;)Landroid/database/Cursor;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(constraint);
			}
		}

		public ICursor RunQueryOnBackgroundThread(string constraint)
		{
			Java.Lang.String obj = ((constraint == null) ? null : new Java.Lang.String(constraint));
			ICursor result = RunQueryOnBackgroundThread(obj);
			obj?.Dispose();
			return result;
		}

		private static Delegate GetSwapCursor_Landroid_database_Cursor_Handler()
		{
			if ((object)cb_swapCursor_Landroid_database_Cursor_ == null)
			{
				cb_swapCursor_Landroid_database_Cursor_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SwapCursor_Landroid_database_Cursor_));
			}
			return cb_swapCursor_Landroid_database_Cursor_;
		}

		private static IntPtr n_SwapCursor_Landroid_database_Cursor_(IntPtr jnienv, IntPtr native__this, IntPtr native_newCursor)
		{
			CursorAdapter cursorAdapter = Java.Lang.Object.GetObject<CursorAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICursor newCursor = Java.Lang.Object.GetObject<ICursor>(native_newCursor, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(cursorAdapter.SwapCursor(newCursor));
		}

		[Register("swapCursor", "(Landroid/database/Cursor;)Landroid/database/Cursor;", "GetSwapCursor_Landroid_database_Cursor_Handler")]
		public unsafe virtual ICursor SwapCursor(ICursor newCursor)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((newCursor == null) ? IntPtr.Zero : ((Java.Lang.Object)newCursor).Handle);
				return Java.Lang.Object.GetObject<ICursor>(_members.InstanceMethods.InvokeVirtualObjectMethod("swapCursor.(Landroid/database/Cursor;)Landroid/database/Cursor;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(newCursor);
			}
		}
	}
	[Register("androidx/cursoradapter/widget/CursorAdapter", DoNotGenerateAcw = true)]
	internal class CursorAdapterInvoker : CursorAdapter
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/cursoradapter/widget/CursorAdapter", typeof(CursorAdapterInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public CursorAdapterInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("bindView", "(Landroid/view/View;Landroid/content/Context;Landroid/database/Cursor;)V", "GetBindView_Landroid_view_View_Landroid_content_Context_Landroid_database_Cursor_Handler")]
		public unsafe override void BindView(View view, Context context, ICursor cursor)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue((cursor == null) ? IntPtr.Zero : ((Java.Lang.Object)cursor).Handle);
				_members.InstanceMethods.InvokeAbstractVoidMethod("bindView.(Landroid/view/View;Landroid/content/Context;Landroid/database/Cursor;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(view);
				GC.KeepAlive(context);
				GC.KeepAlive(cursor);
			}
		}

		[Register("newView", "(Landroid/content/Context;Landroid/database/Cursor;Landroid/view/ViewGroup;)Landroid/view/View;", "GetNewView_Landroid_content_Context_Landroid_database_Cursor_Landroid_view_ViewGroup_Handler")]
		public unsafe override View NewView(Context context, ICursor cursor, ViewGroup parent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((cursor == null) ? IntPtr.Zero : ((Java.Lang.Object)cursor).Handle);
				ptr[2] = new JniArgumentValue(parent?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<View>(_members.InstanceMethods.InvokeAbstractObjectMethod("newView.(Landroid/content/Context;Landroid/database/Cursor;Landroid/view/ViewGroup;)Landroid/view/View;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(cursor);
				GC.KeepAlive(parent);
			}
		}
	}
}
