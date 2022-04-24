# 编译原理实验作业

## 一、分词器

### 1. 测试程序

```c
5. .5
int ab,2ab1;
for (f12=10.8;f12<=10.98.5;f21++)
   f12+=f21+++1000
100 + 100
100+100
-100
-19.8
+10.8
```

### 2. 结果截图

![结果截图](./images/1.jpg)

## 二、自动机

1. 判断正规式合法性
2. 正规式转NFA
3. NFA转DFA
   - 从正规式
   ![图 3](images/README/nfa2dfa1.gif)
   - 文件读入
   ![图 4](images/README/nfa2dfa2.gif)

   主要代码：
   ```csharp
   /// <summary>
   /// 将NFA转换为DFA
   /// 输入NFA，例：
   /// 起始状态：0 
   /// 终止状态：10
   /// 0 # 1
   /// 1 # 2
   /// 1 # 4
   /// 2 a 3
   /// 4 b 5
   /// 3 # 6
   /// 5 # 6
   /// 6 # 1
   /// 6 # 7
   /// 7 a 8
   /// 0 # 7
   /// 8 b 9
   /// 9 b 10
   /// </summary>
   /// <returns>转换后的DFA</returns>
   public PathList nfa2dfa()
   {
       // 输入字符集 如上例为 [a, b]
       inputCharSets = getInputCharSets(nfaPathList).ToList();
       dfaPathList = null;
       // C为一个列表 存放一系列有序集合（SortedSet）（同书中实例代码段的C）
       C = new List<SortedSet<int>>();
       Debug.WriteLine("nfa to dfa...");
       // 待构造的dfa的路径序列
       List<Path> paths = new List<Path>();
       int cnt = 0; // 当前C中已经存放了多少个集合

       SortedSet<int> set = new SortedSet<int>();
       set.Add(nfaPathList.head.ElementAt(0));

       /**
        * 初始时K0的闭包是C中的唯一成员
        * 这里说一下tStr列表的作用：
        * tStr集合保存的是一系列由C中的集合转换而成的字符串，由于集合是有序集合（集合中的元素唯一）
        * 所以不同的有序集合所转换为的字符串肯定也是不同的，所以这里用tStr来检测，新构成的集合是否存在过 
        **/
       C.Add(emptyClosure(set));
       tStr.Add(String.Join(",", emptyClosure(set).ToList()));
       cnt++;
       Debug.WriteLine("closure(0): " + String.Join(",", emptyClosure(set).ToList()));

       // 注意这个循环中的C.Count 在后期向C中添加元素时这个Count是会增加的
       for (int i = 0; i < C.Count; i++)
       {
           // 这个t即为未被标记的集合
           SortedSet<int> t = C[i];
           // 用输入字符集中的每一个字符 对t进行move操作并求闭包
           inputCharSets.ForEach(val =>
           {
               // 对t进行move操作并求闭包得到集合u
               SortedSet<int> u = emptyClosure(move(t, val, nfaPathList));
               // 将得到的u转换为对应的字符串 （例：[1, 2, 3] -> "1, 2, 3"）
               string uStr = string.Join(",", u.ToList());
               // 如果uStr不为空并且未被标记过（这里如果tStr里存在uStr说明它已经被标记过了（因为for循环已经进行过它） 这里需要理解一下）
               if (uStr != "" && !isExist(tStr.ToArray(), uStr))
               {
                   // 这里要添加一条弧 因为能从当前节点i（对应C中一个集合）通过输入字符val进行到cnt
                   paths.Add(new Path(i, cnt++, val));
                   // 将u添加到C
                   C.Add(u);
                   // 将u转换成的字符串添加到tStr
                   tStr.Add(uStr);
               }
               else // 如果u集合已经存在过
               {
                   // 找到它在C中对应到的下标
                   int end = tStr.FindIndex(str => str == uStr);
                   // 添加一条路径 从 i ---val---> end
                   paths.Add(new Path(i, end, val));
               }
           });
       }

       Debug.WriteLine("============result============");
       tStr.ForEach(val => Debug.WriteLine(val.ToString()));

       SortedSet<int> tail = new SortedSet<int>();
       for (int i = 0; i < C.Count; i++)
           if (C[i].Contains(nfaPathList.tail.ElementAt(0)))
               tail.Add(i);
       dfaPathList = new PathList(new SortedSet<int>() { 0 }, tail, paths);
       return dfaPathList;
   }
   ```

   更多代码参见：[这里](https://github.com/mayapony/compiler-app/commit/d09aef4ea626247c2f39ff39c83f0e00458b58be)
