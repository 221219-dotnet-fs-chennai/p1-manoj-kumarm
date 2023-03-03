//1
public void Merge(int[] nums1, int m, int[] nums2, int n)
{
  int last = m + n - 1;
  int a = m - 1;
  int b = n - 1;
  while (m > 0 && n > 0)
  {
    if (nums2[b] > nums1[a])
    {
      nums1[last] = nums2[b];
      b--;
      n--;
    }
    else
    {
      nums1[last] = nums1[a];
      a--;
      m--;
    }
    last--;
  }
  while (n > 0)
  {
    nums1[last] = nums2[b];
    b--;
    n--;
    last--;
  }
  System.Console.WriteLine(nums1);
}

//2  
public void RemoveDuplicates(int[] nums)
{
  if (nums.Length == 0)
  {
    System.Console.WriteLine(nums.Length);
  }
  HashSet<int> set1 = new HashSet<int>();
  for (int i = 0; i < nums.Length; i++)
  {
    set1.Add(nums[i]);
  }
  foreach (int i in set1)
  {
    System.Console.Write(i);
  }
}

//2
public int RemoveDuplicates(int[] nums)
{
  if (nums.Length == 0)
  {
    return nums.Length;
  }
  // HashSet<int> set1 = new HashSet<int>();
  // for(int i = 0; i < nums.Length; i++){
  //     set1.Add(nums[i]);
  // }
  int i = 0;
  for (int j = 1; j < nums.Length; j++)
  {
    if (nums[i] == nums[j])
    {
      continue;
    }
    else
    {
      i++;
      nums[i] = nums[j];
    }
  }
  return i + 1;
}



//3    
int[] arr = new int[] { 4, 4, 8, 8, 8, 15, 16, 23, 23, 42 };
int t = 8;
Dictionary<int, int> map = new();
foreach (int i in arr)
{
  if (map.ContainsKey(i)) map[i]++;
  else map.Add(i, 1);
}
foreach (var item in map)
{
  if (item.Key.Equals(t))
  {
    System.Console.WriteLine(item.Value);
  }
  // System.Console.WriteLine(item.Key + "|"+item.Value);
}

//4
List<int> arr = new() { 1, 4, 10, -3 };
int t = 14;
for (int i = 0; i < arr.Count; i++)
{
  for (int j = 1; j < arr.Count; j++)
  {
    if (arr[i] + arr[j] == t)
    {
      System.Console.WriteLine(i + " " + j);
      arr.Remove(arr[j]);
      arr.Remove(arr[i]);
    }
  }
}

//5
List<int> arr = new() { -8, -3, -10, -32, -1 };
SortedSet<int> set1 = new();
foreach (int item in arr) set1.Add(item);
System.Console.WriteLine("Minimum: " + set1.First());
System.Console.WriteLine("Maximum: " + set1.Last());

//6
int[] arr = new int[] { 1, 3, 5, 6 };
int k = 5;
int bs(int[] arr, int k)
{
  int left = 0;
  int right = arr.Length - 1;
  while (left <= right)
  {
    int mid = (left + right) / 2;
    if (arr[mid] == k)
    {
      return mid;
    }
    else if (arr[mid] < k)
    {
      left = mid + 1;
    }
    else
    {
      right = mid - 1;
    }
  }
  return -1;
}

int result = bs(arr, k);
if (result != -1)
{
  System.Console.WriteLine(result);
}
else if (result == -1)
{
  int i = 0;
  for (int j = 1; j < arr.Length; j++)
  {
    if (k > arr[i] && k < arr[j])
    {
      i++;
      System.Console.WriteLine(j);
    }
  }
}

//7
List<int> unSorted = new() { 1, 14, 2, 16, 10, 20 };
var sorted = Merge(unSorted);
System.Console.WriteLine(sorted.ElementAt(sorted.Count - 3));

List<int> Merge(List<int> unsorted)
{
  if (unsorted.Count <= 1)
  {
    return unsorted;
  }
  List<int> left = new();
  List<int> right = new();
  int mid = unsorted.Count / 2;
  for (int i = 0; i < mid; i++)
  {
    left.Add(unsorted.ElementAt(i));
  }
  for (int i = mid; i < unsorted.Count; i++)
  {
    right.Add(unsorted.ElementAt(i));
  }
  left = Merge(left);
  right = Merge(right);
  return MergeSort(left, right);
}

List<int> MergeSort(List<int> left, List<int> right)
{
  List<int> sorted = new();
  while (left.Count > 0 || right.Count > 0)
  {
    if (left.Count > 0 && right.Count > 0)
    {
      if (left.First() <= right.First())
      {
        sorted.Add(left.First());
        left.Remove(left.First());
      }
      else
      {
        sorted.Add(right.First());
        right.Remove(right.First());
      }
    }
    else if (left.Count > 0)
    {
      sorted.Add(left.First());
      left.Remove(left.First());
    }
    else if (right.Count > 0)
    {
      sorted.Add(right.First());
      right.Remove(right.First());
    }
  }
  return sorted;
}

//8
int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7 };
int d = 3;
int l = 0;
int r = arr.Length - 1;
while (l < r)
{
  int temp = arr[l];
  arr[l] = arr[r];
  arr[r] = temp;
  l++;
  r--;
}

int l1 = 0;
int r1 = (arr.Length - d) - 1;
while (l1 < r1)
{
  int temp = arr[l1];
  arr[l1] = arr[r1];
  arr[r1] = temp;
  l1++;
  r1--;
}

int l2 = (arr.Length - d);
int r2 = arr.Length - 1;
while (l2 < r2)
{
  int temp = arr[l2];
  arr[l2] = arr[r2];
  arr[r2] = temp;
  l2++;
  r2--;
}

foreach (var item in arr)
{
  System.Console.Write(item + " ");
}


//9
int[] arr = new int[] { -4, 1, -8, 9, 6 };
Array.Sort(arr);
int p1 = arr[0] * arr[1] * arr[arr.Length - 1];
int p2 = arr[arr.Length - 1] * arr[arr.Length - 2] * arr[arr.Length - 3];
if (p1 > p2 || p1 == p2)
{
  System.Console.WriteLine($"{arr[0]}, {arr[1]}, {arr[arr.Length - 1]}");
}
else
{
  System.Console.WriteLine($"{arr[arr.Length - 1]}, {arr[arr.Length - 2]}, {arr[arr.Length - 3]}");
}



// string

//1
string s = "Mkhaeioutgh";
s = s.ToLower();
string res = "";
char[] arr = s.ToCharArray();
for (int i = 0; i < arr.Length; i++)
{
  if (arr[i] == 'a' || arr[i] == 'e' || arr[i] == 'i' || arr[i] == 'o' || arr[i] == 'u')
  {
    arr[i] = '\0';
  }
}
foreach (var item in arr)
{
  if (item != '\0')
  {
    res += item.ToString();
  }
}
System.Console.WriteLine(res);

//3
string s = "255.100.50.0";
string res = s.Replace(".", "[.]");
System.Console.WriteLine(res);

//4
string s = "Hello";
string res = "";
foreach (Char i in s)
{
  char c = '\0';
  if (Char.IsUpper(i))
  {
    c = Char.ToLower(i);
    res += c.ToString();
  }
  else
  {
    res += i.ToString();
  }
}
System.Console.WriteLine(res);

//5
string s = "afteracademy";
Dictionary<char, int> map = new();
foreach (var item in s)
{
  if (map.ContainsKey(item)) map[item]++;
  else map.Add(item, 1);
}
char c = '\0';
foreach (var item in map)
{
  if (item.Value == 1)
  {
    c = item.Key;
    break;
  }
}
for (int i = 0; i < s.Length; i++)
{
  if (s[i] == c) System.Console.WriteLine(i);
}

//6
string s = "car";
string t = "rat";
if (s.Length != t.Length) System.Console.WriteLine("false");
Dictionary<char, int> map = new();
foreach (var i in s)
{
  if (map.ContainsKey(i)) map[i]++;
  else map.Add(i, 1);
}

foreach (var i in t)
{
  if (map.ContainsKey(i)) map[i]--;
  else map.Add(i, 1);
}

bool flag = true;
foreach (var item in map)
{
  if (Convert.ToBoolean(item.Value)) flag = false;
}
System.Console.WriteLine(flag);