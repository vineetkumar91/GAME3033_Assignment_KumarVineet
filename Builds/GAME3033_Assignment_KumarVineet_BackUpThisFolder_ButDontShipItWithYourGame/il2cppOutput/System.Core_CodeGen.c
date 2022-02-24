#include "pch-c.h"
#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include "codegen/il2cpp-codegen-metadata.h"





// 0x00000001 System.Exception System.Linq.Error::ArgumentNull(System.String)
extern void Error_ArgumentNull_m0EDA0D46D72CA692518E3E2EB75B48044D8FD41E (void);
// 0x00000002 System.Exception System.Linq.Error::MoreThanOneMatch()
extern void Error_MoreThanOneMatch_m4C4756AF34A76EF12F3B2B6D8C78DE547F0FBCF8 (void);
// 0x00000003 System.Exception System.Linq.Error::NoElements()
extern void Error_NoElements_mB89E91246572F009281D79730950808F17C3F353 (void);
// 0x00000004 System.Exception System.Linq.Error::NoMatch()
extern void Error_NoMatch_mA0FE78EC100066FA506B4C1C3AEC2E9E2DB79945 (void);
// 0x00000005 System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable::Where(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x00000006 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable::Select(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,TResult>)
// 0x00000007 System.Func`2<TSource,System.Boolean> System.Linq.Enumerable::CombinePredicates(System.Func`2<TSource,System.Boolean>,System.Func`2<TSource,System.Boolean>)
// 0x00000008 System.Func`2<TSource,TResult> System.Linq.Enumerable::CombineSelectors(System.Func`2<TSource,TMiddle>,System.Func`2<TMiddle,TResult>)
// 0x00000009 System.Linq.IOrderedEnumerable`1<TSource> System.Linq.Enumerable::OrderBy(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,TKey>)
// 0x0000000A System.Linq.IOrderedEnumerable`1<TSource> System.Linq.Enumerable::ThenBy(System.Linq.IOrderedEnumerable`1<TSource>,System.Func`2<TSource,TKey>)
// 0x0000000B TSource[] System.Linq.Enumerable::ToArray(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x0000000C System.Collections.Generic.List`1<TSource> System.Linq.Enumerable::ToList(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x0000000D TSource System.Linq.Enumerable::First(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x0000000E TSource System.Linq.Enumerable::First(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x0000000F TSource System.Linq.Enumerable::FirstOrDefault(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x00000010 TSource System.Linq.Enumerable::Last(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x00000011 TSource System.Linq.Enumerable::SingleOrDefault(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x00000012 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable::Empty()
// 0x00000013 System.Boolean System.Linq.Enumerable::Any(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x00000014 System.Boolean System.Linq.Enumerable::Any(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x00000015 System.Boolean System.Linq.Enumerable::All(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x00000016 System.Int32 System.Linq.Enumerable::Count(System.Collections.Generic.IEnumerable`1<TSource>)
// 0x00000017 System.Boolean System.Linq.Enumerable::Contains(System.Collections.Generic.IEnumerable`1<TSource>,TSource)
// 0x00000018 System.Boolean System.Linq.Enumerable::Contains(System.Collections.Generic.IEnumerable`1<TSource>,TSource,System.Collections.Generic.IEqualityComparer`1<TSource>)
// 0x00000019 System.Void System.Linq.Enumerable/Iterator`1::.ctor()
// 0x0000001A TSource System.Linq.Enumerable/Iterator`1::get_Current()
// 0x0000001B System.Linq.Enumerable/Iterator`1<TSource> System.Linq.Enumerable/Iterator`1::Clone()
// 0x0000001C System.Void System.Linq.Enumerable/Iterator`1::Dispose()
// 0x0000001D System.Collections.Generic.IEnumerator`1<TSource> System.Linq.Enumerable/Iterator`1::GetEnumerator()
// 0x0000001E System.Boolean System.Linq.Enumerable/Iterator`1::MoveNext()
// 0x0000001F System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/Iterator`1::Select(System.Func`2<TSource,TResult>)
// 0x00000020 System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable/Iterator`1::Where(System.Func`2<TSource,System.Boolean>)
// 0x00000021 System.Object System.Linq.Enumerable/Iterator`1::System.Collections.IEnumerator.get_Current()
// 0x00000022 System.Collections.IEnumerator System.Linq.Enumerable/Iterator`1::System.Collections.IEnumerable.GetEnumerator()
// 0x00000023 System.Void System.Linq.Enumerable/Iterator`1::System.Collections.IEnumerator.Reset()
// 0x00000024 System.Void System.Linq.Enumerable/WhereEnumerableIterator`1::.ctor(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x00000025 System.Linq.Enumerable/Iterator`1<TSource> System.Linq.Enumerable/WhereEnumerableIterator`1::Clone()
// 0x00000026 System.Void System.Linq.Enumerable/WhereEnumerableIterator`1::Dispose()
// 0x00000027 System.Boolean System.Linq.Enumerable/WhereEnumerableIterator`1::MoveNext()
// 0x00000028 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereEnumerableIterator`1::Select(System.Func`2<TSource,TResult>)
// 0x00000029 System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable/WhereEnumerableIterator`1::Where(System.Func`2<TSource,System.Boolean>)
// 0x0000002A System.Void System.Linq.Enumerable/WhereArrayIterator`1::.ctor(TSource[],System.Func`2<TSource,System.Boolean>)
// 0x0000002B System.Linq.Enumerable/Iterator`1<TSource> System.Linq.Enumerable/WhereArrayIterator`1::Clone()
// 0x0000002C System.Boolean System.Linq.Enumerable/WhereArrayIterator`1::MoveNext()
// 0x0000002D System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereArrayIterator`1::Select(System.Func`2<TSource,TResult>)
// 0x0000002E System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable/WhereArrayIterator`1::Where(System.Func`2<TSource,System.Boolean>)
// 0x0000002F System.Void System.Linq.Enumerable/WhereListIterator`1::.ctor(System.Collections.Generic.List`1<TSource>,System.Func`2<TSource,System.Boolean>)
// 0x00000030 System.Linq.Enumerable/Iterator`1<TSource> System.Linq.Enumerable/WhereListIterator`1::Clone()
// 0x00000031 System.Boolean System.Linq.Enumerable/WhereListIterator`1::MoveNext()
// 0x00000032 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereListIterator`1::Select(System.Func`2<TSource,TResult>)
// 0x00000033 System.Collections.Generic.IEnumerable`1<TSource> System.Linq.Enumerable/WhereListIterator`1::Where(System.Func`2<TSource,System.Boolean>)
// 0x00000034 System.Void System.Linq.Enumerable/WhereSelectEnumerableIterator`2::.ctor(System.Collections.Generic.IEnumerable`1<TSource>,System.Func`2<TSource,System.Boolean>,System.Func`2<TSource,TResult>)
// 0x00000035 System.Linq.Enumerable/Iterator`1<TResult> System.Linq.Enumerable/WhereSelectEnumerableIterator`2::Clone()
// 0x00000036 System.Void System.Linq.Enumerable/WhereSelectEnumerableIterator`2::Dispose()
// 0x00000037 System.Boolean System.Linq.Enumerable/WhereSelectEnumerableIterator`2::MoveNext()
// 0x00000038 System.Collections.Generic.IEnumerable`1<TResult2> System.Linq.Enumerable/WhereSelectEnumerableIterator`2::Select(System.Func`2<TResult,TResult2>)
// 0x00000039 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereSelectEnumerableIterator`2::Where(System.Func`2<TResult,System.Boolean>)
// 0x0000003A System.Void System.Linq.Enumerable/WhereSelectArrayIterator`2::.ctor(TSource[],System.Func`2<TSource,System.Boolean>,System.Func`2<TSource,TResult>)
// 0x0000003B System.Linq.Enumerable/Iterator`1<TResult> System.Linq.Enumerable/WhereSelectArrayIterator`2::Clone()
// 0x0000003C System.Boolean System.Linq.Enumerable/WhereSelectArrayIterator`2::MoveNext()
// 0x0000003D System.Collections.Generic.IEnumerable`1<TResult2> System.Linq.Enumerable/WhereSelectArrayIterator`2::Select(System.Func`2<TResult,TResult2>)
// 0x0000003E System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereSelectArrayIterator`2::Where(System.Func`2<TResult,System.Boolean>)
// 0x0000003F System.Void System.Linq.Enumerable/WhereSelectListIterator`2::.ctor(System.Collections.Generic.List`1<TSource>,System.Func`2<TSource,System.Boolean>,System.Func`2<TSource,TResult>)
// 0x00000040 System.Linq.Enumerable/Iterator`1<TResult> System.Linq.Enumerable/WhereSelectListIterator`2::Clone()
// 0x00000041 System.Boolean System.Linq.Enumerable/WhereSelectListIterator`2::MoveNext()
// 0x00000042 System.Collections.Generic.IEnumerable`1<TResult2> System.Linq.Enumerable/WhereSelectListIterator`2::Select(System.Func`2<TResult,TResult2>)
// 0x00000043 System.Collections.Generic.IEnumerable`1<TResult> System.Linq.Enumerable/WhereSelectListIterator`2::Where(System.Func`2<TResult,System.Boolean>)
// 0x00000044 System.Void System.Linq.Enumerable/<>c__DisplayClass6_0`1::.ctor()
// 0x00000045 System.Boolean System.Linq.Enumerable/<>c__DisplayClass6_0`1::<CombinePredicates>b__0(TSource)
// 0x00000046 System.Void System.Linq.Enumerable/<>c__DisplayClass7_0`3::.ctor()
// 0x00000047 TResult System.Linq.Enumerable/<>c__DisplayClass7_0`3::<CombineSelectors>b__0(TSource)
// 0x00000048 System.Void System.Linq.EmptyEnumerable`1::.cctor()
// 0x00000049 System.Linq.IOrderedEnumerable`1<TElement> System.Linq.IOrderedEnumerable`1::CreateOrderedEnumerable(System.Func`2<TElement,TKey>,System.Collections.Generic.IComparer`1<TKey>,System.Boolean)
// 0x0000004A System.Collections.Generic.IEnumerator`1<TElement> System.Linq.OrderedEnumerable`1::GetEnumerator()
// 0x0000004B System.Linq.EnumerableSorter`1<TElement> System.Linq.OrderedEnumerable`1::GetEnumerableSorter(System.Linq.EnumerableSorter`1<TElement>)
// 0x0000004C System.Collections.IEnumerator System.Linq.OrderedEnumerable`1::System.Collections.IEnumerable.GetEnumerator()
// 0x0000004D System.Linq.IOrderedEnumerable`1<TElement> System.Linq.OrderedEnumerable`1::System.Linq.IOrderedEnumerable<TElement>.CreateOrderedEnumerable(System.Func`2<TElement,TKey>,System.Collections.Generic.IComparer`1<TKey>,System.Boolean)
// 0x0000004E System.Void System.Linq.OrderedEnumerable`1::.ctor()
// 0x0000004F System.Void System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::.ctor(System.Int32)
// 0x00000050 System.Void System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::System.IDisposable.Dispose()
// 0x00000051 System.Boolean System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::MoveNext()
// 0x00000052 TElement System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::System.Collections.Generic.IEnumerator<TElement>.get_Current()
// 0x00000053 System.Void System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::System.Collections.IEnumerator.Reset()
// 0x00000054 System.Object System.Linq.OrderedEnumerable`1/<GetEnumerator>d__1::System.Collections.IEnumerator.get_Current()
// 0x00000055 System.Void System.Linq.OrderedEnumerable`2::.ctor(System.Collections.Generic.IEnumerable`1<TElement>,System.Func`2<TElement,TKey>,System.Collections.Generic.IComparer`1<TKey>,System.Boolean)
// 0x00000056 System.Linq.EnumerableSorter`1<TElement> System.Linq.OrderedEnumerable`2::GetEnumerableSorter(System.Linq.EnumerableSorter`1<TElement>)
// 0x00000057 System.Void System.Linq.EnumerableSorter`1::ComputeKeys(TElement[],System.Int32)
// 0x00000058 System.Int32 System.Linq.EnumerableSorter`1::CompareKeys(System.Int32,System.Int32)
// 0x00000059 System.Int32[] System.Linq.EnumerableSorter`1::Sort(TElement[],System.Int32)
// 0x0000005A System.Void System.Linq.EnumerableSorter`1::QuickSort(System.Int32[],System.Int32,System.Int32)
// 0x0000005B System.Void System.Linq.EnumerableSorter`1::.ctor()
// 0x0000005C System.Void System.Linq.EnumerableSorter`2::.ctor(System.Func`2<TElement,TKey>,System.Collections.Generic.IComparer`1<TKey>,System.Boolean,System.Linq.EnumerableSorter`1<TElement>)
// 0x0000005D System.Void System.Linq.EnumerableSorter`2::ComputeKeys(TElement[],System.Int32)
// 0x0000005E System.Int32 System.Linq.EnumerableSorter`2::CompareKeys(System.Int32,System.Int32)
// 0x0000005F System.Void System.Linq.Buffer`1::.ctor(System.Collections.Generic.IEnumerable`1<TElement>)
// 0x00000060 TElement[] System.Linq.Buffer`1::ToArray()
// 0x00000061 System.Void System.Collections.Generic.HashSet`1::.ctor()
// 0x00000062 System.Void System.Collections.Generic.HashSet`1::.ctor(System.Collections.Generic.IEqualityComparer`1<T>)
// 0x00000063 System.Void System.Collections.Generic.HashSet`1::.ctor(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)
// 0x00000064 System.Void System.Collections.Generic.HashSet`1::System.Collections.Generic.ICollection<T>.Add(T)
// 0x00000065 System.Void System.Collections.Generic.HashSet`1::Clear()
// 0x00000066 System.Boolean System.Collections.Generic.HashSet`1::Contains(T)
// 0x00000067 System.Void System.Collections.Generic.HashSet`1::CopyTo(T[],System.Int32)
// 0x00000068 System.Boolean System.Collections.Generic.HashSet`1::Remove(T)
// 0x00000069 System.Int32 System.Collections.Generic.HashSet`1::get_Count()
// 0x0000006A System.Boolean System.Collections.Generic.HashSet`1::System.Collections.Generic.ICollection<T>.get_IsReadOnly()
// 0x0000006B System.Collections.Generic.HashSet`1/Enumerator<T> System.Collections.Generic.HashSet`1::GetEnumerator()
// 0x0000006C System.Collections.Generic.IEnumerator`1<T> System.Collections.Generic.HashSet`1::System.Collections.Generic.IEnumerable<T>.GetEnumerator()
// 0x0000006D System.Collections.IEnumerator System.Collections.Generic.HashSet`1::System.Collections.IEnumerable.GetEnumerator()
// 0x0000006E System.Void System.Collections.Generic.HashSet`1::GetObjectData(System.Runtime.Serialization.SerializationInfo,System.Runtime.Serialization.StreamingContext)
// 0x0000006F System.Void System.Collections.Generic.HashSet`1::OnDeserialization(System.Object)
// 0x00000070 System.Boolean System.Collections.Generic.HashSet`1::Add(T)
// 0x00000071 System.Void System.Collections.Generic.HashSet`1::CopyTo(T[])
// 0x00000072 System.Void System.Collections.Generic.HashSet`1::CopyTo(T[],System.Int32,System.Int32)
// 0x00000073 System.Void System.Collections.Generic.HashSet`1::Initialize(System.Int32)
// 0x00000074 System.Void System.Collections.Generic.HashSet`1::IncreaseCapacity()
// 0x00000075 System.Void System.Collections.Generic.HashSet`1::SetCapacity(System.Int32)
// 0x00000076 System.Boolean System.Collections.Generic.HashSet`1::AddIfNotPresent(T)
// 0x00000077 System.Int32 System.Collections.Generic.HashSet`1::InternalGetHashCode(T)
// 0x00000078 System.Void System.Collections.Generic.HashSet`1/Enumerator::.ctor(System.Collections.Generic.HashSet`1<T>)
// 0x00000079 System.Void System.Collections.Generic.HashSet`1/Enumerator::Dispose()
// 0x0000007A System.Boolean System.Collections.Generic.HashSet`1/Enumerator::MoveNext()
// 0x0000007B T System.Collections.Generic.HashSet`1/Enumerator::get_Current()
// 0x0000007C System.Object System.Collections.Generic.HashSet`1/Enumerator::System.Collections.IEnumerator.get_Current()
// 0x0000007D System.Void System.Collections.Generic.HashSet`1/Enumerator::System.Collections.IEnumerator.Reset()
static Il2CppMethodPointer s_methodPointers[125] = 
{
	Error_ArgumentNull_m0EDA0D46D72CA692518E3E2EB75B48044D8FD41E,
	Error_MoreThanOneMatch_m4C4756AF34A76EF12F3B2B6D8C78DE547F0FBCF8,
	Error_NoElements_mB89E91246572F009281D79730950808F17C3F353,
	Error_NoMatch_mA0FE78EC100066FA506B4C1C3AEC2E9E2DB79945,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
};
static const int32_t s_InvokerIndices[125] = 
{
	4395,
	4583,
	4583,
	4583,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
	-1,
};
static const Il2CppTokenRangePair s_rgctxIndices[45] = 
{
	{ 0x02000004, { 73, 4 } },
	{ 0x02000005, { 77, 9 } },
	{ 0x02000006, { 88, 7 } },
	{ 0x02000007, { 97, 10 } },
	{ 0x02000008, { 109, 11 } },
	{ 0x02000009, { 123, 9 } },
	{ 0x0200000A, { 135, 12 } },
	{ 0x0200000B, { 150, 1 } },
	{ 0x0200000C, { 151, 2 } },
	{ 0x0200000D, { 153, 2 } },
	{ 0x0200000F, { 155, 3 } },
	{ 0x02000010, { 160, 5 } },
	{ 0x02000011, { 165, 7 } },
	{ 0x02000012, { 172, 3 } },
	{ 0x02000013, { 175, 7 } },
	{ 0x02000014, { 182, 4 } },
	{ 0x02000015, { 186, 21 } },
	{ 0x02000017, { 207, 2 } },
	{ 0x06000005, { 0, 10 } },
	{ 0x06000006, { 10, 10 } },
	{ 0x06000007, { 20, 5 } },
	{ 0x06000008, { 25, 5 } },
	{ 0x06000009, { 30, 2 } },
	{ 0x0600000A, { 32, 1 } },
	{ 0x0600000B, { 33, 3 } },
	{ 0x0600000C, { 36, 2 } },
	{ 0x0600000D, { 38, 4 } },
	{ 0x0600000E, { 42, 3 } },
	{ 0x0600000F, { 45, 4 } },
	{ 0x06000010, { 49, 4 } },
	{ 0x06000011, { 53, 3 } },
	{ 0x06000012, { 56, 1 } },
	{ 0x06000013, { 57, 1 } },
	{ 0x06000014, { 58, 3 } },
	{ 0x06000015, { 61, 3 } },
	{ 0x06000016, { 64, 2 } },
	{ 0x06000017, { 66, 2 } },
	{ 0x06000018, { 68, 5 } },
	{ 0x06000028, { 86, 2 } },
	{ 0x0600002D, { 95, 2 } },
	{ 0x06000032, { 107, 2 } },
	{ 0x06000038, { 120, 3 } },
	{ 0x0600003D, { 132, 3 } },
	{ 0x06000042, { 147, 3 } },
	{ 0x0600004D, { 158, 2 } },
};
static const Il2CppRGCTXDefinition s_rgctxValues[209] = 
{
	{ (Il2CppRGCTXDataType)2, 2097 },
	{ (Il2CppRGCTXDataType)3, 10421 },
	{ (Il2CppRGCTXDataType)2, 3473 },
	{ (Il2CppRGCTXDataType)2, 2916 },
	{ (Il2CppRGCTXDataType)3, 17701 },
	{ (Il2CppRGCTXDataType)2, 2196 },
	{ (Il2CppRGCTXDataType)2, 2923 },
	{ (Il2CppRGCTXDataType)3, 17736 },
	{ (Il2CppRGCTXDataType)2, 2918 },
	{ (Il2CppRGCTXDataType)3, 17713 },
	{ (Il2CppRGCTXDataType)2, 2098 },
	{ (Il2CppRGCTXDataType)3, 10422 },
	{ (Il2CppRGCTXDataType)2, 3501 },
	{ (Il2CppRGCTXDataType)2, 2925 },
	{ (Il2CppRGCTXDataType)3, 17748 },
	{ (Il2CppRGCTXDataType)2, 2213 },
	{ (Il2CppRGCTXDataType)2, 2933 },
	{ (Il2CppRGCTXDataType)3, 17890 },
	{ (Il2CppRGCTXDataType)2, 2929 },
	{ (Il2CppRGCTXDataType)3, 17813 },
	{ (Il2CppRGCTXDataType)2, 743 },
	{ (Il2CppRGCTXDataType)3, 31 },
	{ (Il2CppRGCTXDataType)3, 32 },
	{ (Il2CppRGCTXDataType)2, 1301 },
	{ (Il2CppRGCTXDataType)3, 7340 },
	{ (Il2CppRGCTXDataType)2, 744 },
	{ (Il2CppRGCTXDataType)3, 39 },
	{ (Il2CppRGCTXDataType)3, 40 },
	{ (Il2CppRGCTXDataType)2, 1311 },
	{ (Il2CppRGCTXDataType)3, 7346 },
	{ (Il2CppRGCTXDataType)2, 2591 },
	{ (Il2CppRGCTXDataType)3, 15269 },
	{ (Il2CppRGCTXDataType)3, 8246 },
	{ (Il2CppRGCTXDataType)2, 876 },
	{ (Il2CppRGCTXDataType)3, 1042 },
	{ (Il2CppRGCTXDataType)3, 1043 },
	{ (Il2CppRGCTXDataType)2, 2197 },
	{ (Il2CppRGCTXDataType)3, 11061 },
	{ (Il2CppRGCTXDataType)2, 1898 },
	{ (Il2CppRGCTXDataType)2, 1455 },
	{ (Il2CppRGCTXDataType)2, 1568 },
	{ (Il2CppRGCTXDataType)2, 1674 },
	{ (Il2CppRGCTXDataType)2, 1569 },
	{ (Il2CppRGCTXDataType)2, 1675 },
	{ (Il2CppRGCTXDataType)3, 7341 },
	{ (Il2CppRGCTXDataType)2, 1899 },
	{ (Il2CppRGCTXDataType)2, 1456 },
	{ (Il2CppRGCTXDataType)2, 1570 },
	{ (Il2CppRGCTXDataType)2, 1676 },
	{ (Il2CppRGCTXDataType)2, 1900 },
	{ (Il2CppRGCTXDataType)2, 1457 },
	{ (Il2CppRGCTXDataType)2, 1571 },
	{ (Il2CppRGCTXDataType)2, 1677 },
	{ (Il2CppRGCTXDataType)2, 1572 },
	{ (Il2CppRGCTXDataType)2, 1678 },
	{ (Il2CppRGCTXDataType)3, 7342 },
	{ (Il2CppRGCTXDataType)2, 1127 },
	{ (Il2CppRGCTXDataType)2, 1560 },
	{ (Il2CppRGCTXDataType)2, 1561 },
	{ (Il2CppRGCTXDataType)2, 1672 },
	{ (Il2CppRGCTXDataType)3, 7339 },
	{ (Il2CppRGCTXDataType)2, 1559 },
	{ (Il2CppRGCTXDataType)2, 1671 },
	{ (Il2CppRGCTXDataType)3, 7338 },
	{ (Il2CppRGCTXDataType)2, 1454 },
	{ (Il2CppRGCTXDataType)2, 1567 },
	{ (Il2CppRGCTXDataType)2, 1453 },
	{ (Il2CppRGCTXDataType)3, 20863 },
	{ (Il2CppRGCTXDataType)3, 6693 },
	{ (Il2CppRGCTXDataType)2, 1206 },
	{ (Il2CppRGCTXDataType)2, 1563 },
	{ (Il2CppRGCTXDataType)2, 1673 },
	{ (Il2CppRGCTXDataType)2, 1772 },
	{ (Il2CppRGCTXDataType)3, 10423 },
	{ (Il2CppRGCTXDataType)3, 10425 },
	{ (Il2CppRGCTXDataType)2, 568 },
	{ (Il2CppRGCTXDataType)3, 10424 },
	{ (Il2CppRGCTXDataType)3, 10433 },
	{ (Il2CppRGCTXDataType)2, 2101 },
	{ (Il2CppRGCTXDataType)2, 2919 },
	{ (Il2CppRGCTXDataType)3, 17714 },
	{ (Il2CppRGCTXDataType)3, 10434 },
	{ (Il2CppRGCTXDataType)2, 1611 },
	{ (Il2CppRGCTXDataType)2, 1703 },
	{ (Il2CppRGCTXDataType)3, 7353 },
	{ (Il2CppRGCTXDataType)3, 20832 },
	{ (Il2CppRGCTXDataType)2, 2930 },
	{ (Il2CppRGCTXDataType)3, 17814 },
	{ (Il2CppRGCTXDataType)3, 10426 },
	{ (Il2CppRGCTXDataType)2, 2100 },
	{ (Il2CppRGCTXDataType)2, 2917 },
	{ (Il2CppRGCTXDataType)3, 17702 },
	{ (Il2CppRGCTXDataType)3, 7352 },
	{ (Il2CppRGCTXDataType)3, 10427 },
	{ (Il2CppRGCTXDataType)3, 20831 },
	{ (Il2CppRGCTXDataType)2, 2926 },
	{ (Il2CppRGCTXDataType)3, 17749 },
	{ (Il2CppRGCTXDataType)3, 10440 },
	{ (Il2CppRGCTXDataType)2, 2102 },
	{ (Il2CppRGCTXDataType)2, 2924 },
	{ (Il2CppRGCTXDataType)3, 17737 },
	{ (Il2CppRGCTXDataType)3, 11104 },
	{ (Il2CppRGCTXDataType)3, 5570 },
	{ (Il2CppRGCTXDataType)3, 7354 },
	{ (Il2CppRGCTXDataType)3, 5569 },
	{ (Il2CppRGCTXDataType)3, 10441 },
	{ (Il2CppRGCTXDataType)3, 20833 },
	{ (Il2CppRGCTXDataType)2, 2934 },
	{ (Il2CppRGCTXDataType)3, 17891 },
	{ (Il2CppRGCTXDataType)3, 10454 },
	{ (Il2CppRGCTXDataType)2, 2104 },
	{ (Il2CppRGCTXDataType)2, 2932 },
	{ (Il2CppRGCTXDataType)3, 17816 },
	{ (Il2CppRGCTXDataType)3, 10455 },
	{ (Il2CppRGCTXDataType)2, 1614 },
	{ (Il2CppRGCTXDataType)2, 1706 },
	{ (Il2CppRGCTXDataType)3, 7358 },
	{ (Il2CppRGCTXDataType)3, 7357 },
	{ (Il2CppRGCTXDataType)2, 2921 },
	{ (Il2CppRGCTXDataType)3, 17716 },
	{ (Il2CppRGCTXDataType)3, 20838 },
	{ (Il2CppRGCTXDataType)2, 2931 },
	{ (Il2CppRGCTXDataType)3, 17815 },
	{ (Il2CppRGCTXDataType)3, 10447 },
	{ (Il2CppRGCTXDataType)2, 2103 },
	{ (Il2CppRGCTXDataType)2, 2928 },
	{ (Il2CppRGCTXDataType)3, 17751 },
	{ (Il2CppRGCTXDataType)3, 7356 },
	{ (Il2CppRGCTXDataType)3, 7355 },
	{ (Il2CppRGCTXDataType)3, 10448 },
	{ (Il2CppRGCTXDataType)2, 2920 },
	{ (Il2CppRGCTXDataType)3, 17715 },
	{ (Il2CppRGCTXDataType)3, 20837 },
	{ (Il2CppRGCTXDataType)2, 2927 },
	{ (Il2CppRGCTXDataType)3, 17750 },
	{ (Il2CppRGCTXDataType)3, 10461 },
	{ (Il2CppRGCTXDataType)2, 2105 },
	{ (Il2CppRGCTXDataType)2, 2936 },
	{ (Il2CppRGCTXDataType)3, 17893 },
	{ (Il2CppRGCTXDataType)3, 11105 },
	{ (Il2CppRGCTXDataType)3, 5572 },
	{ (Il2CppRGCTXDataType)3, 7360 },
	{ (Il2CppRGCTXDataType)3, 7359 },
	{ (Il2CppRGCTXDataType)3, 5571 },
	{ (Il2CppRGCTXDataType)3, 10462 },
	{ (Il2CppRGCTXDataType)2, 2922 },
	{ (Il2CppRGCTXDataType)3, 17717 },
	{ (Il2CppRGCTXDataType)3, 20839 },
	{ (Il2CppRGCTXDataType)2, 2935 },
	{ (Il2CppRGCTXDataType)3, 17892 },
	{ (Il2CppRGCTXDataType)3, 7350 },
	{ (Il2CppRGCTXDataType)3, 7351 },
	{ (Il2CppRGCTXDataType)3, 7361 },
	{ (Il2CppRGCTXDataType)2, 3509 },
	{ (Il2CppRGCTXDataType)2, 1128 },
	{ (Il2CppRGCTXDataType)2, 747 },
	{ (Il2CppRGCTXDataType)3, 82 },
	{ (Il2CppRGCTXDataType)3, 15256 },
	{ (Il2CppRGCTXDataType)2, 2592 },
	{ (Il2CppRGCTXDataType)3, 15270 },
	{ (Il2CppRGCTXDataType)2, 877 },
	{ (Il2CppRGCTXDataType)3, 1044 },
	{ (Il2CppRGCTXDataType)3, 15262 },
	{ (Il2CppRGCTXDataType)3, 5546 },
	{ (Il2CppRGCTXDataType)2, 594 },
	{ (Il2CppRGCTXDataType)3, 15257 },
	{ (Il2CppRGCTXDataType)2, 2588 },
	{ (Il2CppRGCTXDataType)3, 1454 },
	{ (Il2CppRGCTXDataType)2, 894 },
	{ (Il2CppRGCTXDataType)2, 1178 },
	{ (Il2CppRGCTXDataType)3, 5552 },
	{ (Il2CppRGCTXDataType)3, 15258 },
	{ (Il2CppRGCTXDataType)3, 5541 },
	{ (Il2CppRGCTXDataType)3, 5542 },
	{ (Il2CppRGCTXDataType)3, 5540 },
	{ (Il2CppRGCTXDataType)3, 5543 },
	{ (Il2CppRGCTXDataType)2, 1174 },
	{ (Il2CppRGCTXDataType)2, 3556 },
	{ (Il2CppRGCTXDataType)3, 7348 },
	{ (Il2CppRGCTXDataType)3, 5545 },
	{ (Il2CppRGCTXDataType)2, 1538 },
	{ (Il2CppRGCTXDataType)3, 5544 },
	{ (Il2CppRGCTXDataType)2, 1459 },
	{ (Il2CppRGCTXDataType)2, 3505 },
	{ (Il2CppRGCTXDataType)2, 1585 },
	{ (Il2CppRGCTXDataType)2, 1681 },
	{ (Il2CppRGCTXDataType)3, 6712 },
	{ (Il2CppRGCTXDataType)2, 1215 },
	{ (Il2CppRGCTXDataType)3, 8084 },
	{ (Il2CppRGCTXDataType)3, 8085 },
	{ (Il2CppRGCTXDataType)3, 8090 },
	{ (Il2CppRGCTXDataType)2, 1780 },
	{ (Il2CppRGCTXDataType)3, 8087 },
	{ (Il2CppRGCTXDataType)3, 21514 },
	{ (Il2CppRGCTXDataType)2, 1179 },
	{ (Il2CppRGCTXDataType)3, 5561 },
	{ (Il2CppRGCTXDataType)1, 1533 },
	{ (Il2CppRGCTXDataType)2, 3517 },
	{ (Il2CppRGCTXDataType)3, 8086 },
	{ (Il2CppRGCTXDataType)1, 3517 },
	{ (Il2CppRGCTXDataType)1, 1780 },
	{ (Il2CppRGCTXDataType)2, 3577 },
	{ (Il2CppRGCTXDataType)2, 3517 },
	{ (Il2CppRGCTXDataType)3, 8091 },
	{ (Il2CppRGCTXDataType)3, 8089 },
	{ (Il2CppRGCTXDataType)3, 8088 },
	{ (Il2CppRGCTXDataType)2, 449 },
	{ (Il2CppRGCTXDataType)3, 5573 },
	{ (Il2CppRGCTXDataType)2, 577 },
};
extern const CustomAttributesCacheGenerator g_System_Core_AttributeGenerators[];
IL2CPP_EXTERN_C const Il2CppCodeGenModule g_System_Core_CodeGenModule;
const Il2CppCodeGenModule g_System_Core_CodeGenModule = 
{
	"System.Core.dll",
	125,
	s_methodPointers,
	0,
	NULL,
	s_InvokerIndices,
	0,
	NULL,
	45,
	s_rgctxIndices,
	209,
	s_rgctxValues,
	NULL,
	g_System_Core_AttributeGenerators,
	NULL, // module initializer,
	NULL,
	NULL,
	NULL,
};
