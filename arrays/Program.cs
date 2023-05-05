// See https://aka.ms/new-console-template for more information
using arrays;

/* var customArray = new CustomArray<int>(3);

customArray.Insert(9);
customArray.Insert(9);
customArray.Insert(9);
customArray.Insert(10);

for (int i = 0; i < customArray.Length; i++) {
    Console.WriteLine(customArray[i]);
}
Console.WriteLine(customArray.IndexOf(100)); */

var dynamicArray = new DynamicIntArray(6);

dynamicArray.Insert(1);
dynamicArray.Insert(2);
dynamicArray.Insert(3);
dynamicArray.Insert(6);
dynamicArray.Insert(7);
dynamicArray.Insert(8);

var otherArray = dynamicArray.Intersect(0, 1, 3, 6, 8);
for (int i = 0; i < otherArray.Length ; i++) {
    Console.WriteLine(otherArray[i]);
}


