using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Numerics;
namespace ProjectEuler
{
    class Program
    {
        public static int smallestMult(int limit)
        {
            int sum=1;
            List<int> mult = new List<int>();

            for (int i = 2; i <= limit; i++)
            {
                int temp = i;
                for (int j = mult.Count-1; j >=0; j--)
                {
                    if (temp % mult[j] == 0)
                        temp /= mult[j];
                }
                sum *= temp;
                mult.Add(temp);
            }
            return sum;
        }

        public static bool isPrime(long num)
        {
        
            for (long i = 2; i < num; i++)
            {
                if(num%i==0)
                    return false;
            }
            return true;
        }
        //public static bool isPalindrom(int num)
        //{
        //    int startDig = 0;
        //    int endDig = (int)Math.Log10(num);
        //    while (startDig < endDig)
        //    {
        //        int h = (int)(num / Math.Pow(10, endDig)) % 10;
        //        int t=(int)(num / Math.Pow(10, startDig))%10;
        //        if ((int)(num / Math.Pow(10, endDig)) % 10 != (int)(num / Math.Pow(10, startDig)) % 10)
        //            return false;
        //        startDig++;
        //        endDig--;
        //    }
        //    return true;
        //}
        public static bool isPalindrom(int num)
        {

            int temp = ReverseNumber(num);
            return num == temp;
        }
        public static bool isPalindrom(long num)
        {

            long temp = ReverseNumber(num);
            return num == temp;
        }
        public static bool isPalindrom(BigInteger num)
        {

            BigInteger temp = ReverseNumber(num);
            return num == temp;
        }
        public static BigInteger ReverseNumber(BigInteger num)
        {
            char[] numString = num.ToString().ToCharArray();
            Array.Reverse(numString);
            return BigInteger.Parse(new string(numString));
        }
        public static int ReverseNumber(int num)
        {
            char[] numString = num.ToString().ToCharArray();
            Array.Reverse(numString);
           return int.Parse(new string(numString));
        }
        public static long ReverseNumber(long num)
        {
            char[] numString = num.ToString().ToCharArray();
            Array.Reverse(numString);
            return long.Parse(new string(numString));
        }
        public static bool fuIsPrime(int n)
        {
            if (n < 4)
                return true;
            if (n % 2 == 0)
                return false;
            if (n < 9)
                return true;
            if (n % 3 == 0)
                return false;
            else
            {
                int r = (int)Math.Floor(Math.Sqrt(n));
                int f = 5;
                while (f <= r)
                {
                    if (n % f == 0)
                        return false;
                    if (n % (f + 2) == 0)
                        return false;
                    f += 6;
                }
            }
            return true;
        }
        public static void adjacentGrid()
        {
            int[,] grid = new int[20, 20];
            string s = @"08 02 22 97 38 15 00 40 00 75 04 05 07 78 52 12 50 77 91 08
49 49 99 40 17 81 18 57 60 87 17 40 98 43 69 48 04 56 62 00
81 49 31 73 55 79 14 29 93 71 40 67 53 88 30 03 49 13 36 65
52 70 95 23 04 60 11 42 69 24 68 56 01 32 56 71 37 02 36 91
22 31 16 71 51 67 63 89 41 92 36 54 22 40 40 28 66 33 13 80
24 47 32 60 99 03 45 02 44 75 33 53 78 36 84 20 35 17 12 50
32 98 81 28 64 23 67 10 26 38 40 67 59 54 70 66 18 38 64 70
67 26 20 68 02 62 12 20 95 63 94 39 63 08 40 91 66 49 94 21
24 55 58 05 66 73 99 26 97 17 78 78 96 83 14 88 34 89 63 72
21 36 23 09 75 00 76 44 20 45 35 14 00 61 33 97 34 31 33 95
78 17 53 28 22 75 31 67 15 94 03 80 04 62 16 14 09 53 56 92
16 39 05 42 96 35 31 47 55 58 88 24 00 17 54 24 36 29 85 57
86 56 00 48 35 71 89 07 05 44 44 37 44 60 21 58 51 54 17 58
19 80 81 68 05 94 47 69 28 73 92 13 86 52 17 77 04 89 55 40
04 52 08 83 97 35 99 16 07 97 57 32 16 26 26 79 33 27 98 66
88 36 68 87 57 62 20 72 03 46 33 67 46 55 12 32 63 93 53 69
04 42 16 73 38 25 39 11 24 94 72 18 08 46 29 32 40 62 76 36
20 69 36 41 72 30 23 88 34 62 99 69 82 67 59 85 74 04 36 16
20 73 35 29 78 31 90 01 74 31 49 71 48 86 81 16 23 57 05 54
01 70 54 71 83 51 54 69 16 92 33 48 61 43 52 01 89 19 67 48";

            char[] seperators = new char[3] { ' ', '\r', '\n' };
            string[] nums = s.Split(seperators);
            int ss = 0;

            int adjacent = 4;
            adjacent--;
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (nums[ss] == "")
                        ss++;
                    grid[i, j] = int.Parse(nums[ss]);
                    ss++;

                }
            }
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.Write("{0,3}", grid[i, j]);
                }
                Console.WriteLine();
            }
            long product = 1;
            long max = 0;
            // List<int> best = new List<int>();
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    product = 1;
                    #region 90
                    if (j + adjacent < grid.GetLength(1))
                    {
                        for (int k = 0; k <= adjacent; k++)
                        {
                            //best.Add(grid[i, j + k]);
                            product *= grid[i, j + k];

                        }
                        if (product > max)
                            max = product;
                        //  else
                        //  best.Clear();
                    }
                    #endregion
                    product = 1;
                    #region 180
                    if (i + adjacent < grid.GetLength(0))
                    {
                        for (int k = 0; k <= adjacent; k++)
                        {
                            product *= grid[i + k, j];

                        }
                        if (product > max)
                            max = product;
                        //    else
                        //   best.Clear()
                    }
                    #endregion
                    product = 1;
                    #region 135
                    if (i + adjacent < grid.GetLength(0) && j + adjacent < grid.GetLength(1))
                    {
                        for (int k = 0; k <= adjacent; k++)
                        {
                            product *= grid[i + k, j + k];

                        }
                        if (product > max)
                            max = product;
                    }
                    #endregion
                    product = 1;
                    #region 225
                    if (i + adjacent < grid.GetLength(0) && j - adjacent >= 0)
                    {
                        for (int k = 0; k <= adjacent; k++)
                        {
                            product *= grid[i + k, j - k];

                        }
                        if (product > max)
                            max = product;
                    }
                    #endregion
                }
            }
            Console.WriteLine(max);
        }

        static int max = 0;
        public static int DivCount(long num)
        {
            int c=0;
            for (long i = 1; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    c+=2;
                    //Console.Write(i+" ");
                }
            }
            if (Math.Sqrt(num) % 10 == 0)
                c--;
            if (c > max)
            {
                max = c;
                Console.WriteLine(num + "  "+max);
            }
            
            return c;
        }
        public static long DivSum(long num)
        {
            long c = 0;
            for (long i = 1; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    c += i;
                    c += num / i;
                    //Console.Write(i+" ");
                }
            }
            if (Math.Sqrt(num) % 10 == 0)
                c -= (long)Math.Sqrt(num);
            c -= (long)num;
            return c;
        }
        public static void BigSum()
        {
            int c = 0;


            string s = @"37107287533902102798797998220837590246510135740250
46376937677490009712648124896970078050417018260538
74324986199524741059474233309513058123726617309629
91942213363574161572522430563301811072406154908250
23067588207539346171171980310421047513778063246676
89261670696623633820136378418383684178734361726757
28112879812849979408065481931592621691275889832738
44274228917432520321923589422876796487670272189318
47451445736001306439091167216856844588711603153276
70386486105843025439939619828917593665686757934951
62176457141856560629502157223196586755079324193331
64906352462741904929101432445813822663347944758178
92575867718337217661963751590579239728245598838407
58203565325359399008402633568948830189458628227828
80181199384826282014278194139940567587151170094390
35398664372827112653829987240784473053190104293586
86515506006295864861532075273371959191420517255829
71693888707715466499115593487603532921714970056938
54370070576826684624621495650076471787294438377604
53282654108756828443191190634694037855217779295145
36123272525000296071075082563815656710885258350721
45876576172410976447339110607218265236877223636045
17423706905851860660448207621209813287860733969412
81142660418086830619328460811191061556940512689692
51934325451728388641918047049293215058642563049483
62467221648435076201727918039944693004732956340691
15732444386908125794514089057706229429197107928209
55037687525678773091862540744969844508330393682126
18336384825330154686196124348767681297534375946515
80386287592878490201521685554828717201219257766954
78182833757993103614740356856449095527097864797581
16726320100436897842553539920931837441497806860984
48403098129077791799088218795327364475675590848030
87086987551392711854517078544161852424320693150332
59959406895756536782107074926966537676326235447210
69793950679652694742597709739166693763042633987085
41052684708299085211399427365734116182760315001271
65378607361501080857009149939512557028198746004375
35829035317434717326932123578154982629742552737307
94953759765105305946966067683156574377167401875275
88902802571733229619176668713819931811048770190271
25267680276078003013678680992525463401061632866526
36270218540497705585629946580636237993140746255962
24074486908231174977792365466257246923322810917141
91430288197103288597806669760892938638285025333403
34413065578016127815921815005561868836468420090470
23053081172816430487623791969842487255036638784583
11487696932154902810424020138335124462181441773470
63783299490636259666498587618221225225512486764533
67720186971698544312419572409913959008952310058822
95548255300263520781532296796249481641953868218774
76085327132285723110424803456124867697064507995236
37774242535411291684276865538926205024910326572967
23701913275725675285653248258265463092207058596522
29798860272258331913126375147341994889534765745501
18495701454879288984856827726077713721403798879715
38298203783031473527721580348144513491373226651381
34829543829199918180278916522431027392251122869539
40957953066405232632538044100059654939159879593635
29746152185502371307642255121183693803580388584903
41698116222072977186158236678424689157993532961922
62467957194401269043877107275048102390895523597457
23189706772547915061505504953922979530901129967519
86188088225875314529584099251203829009407770775672
11306739708304724483816533873502340845647058077308
82959174767140363198008187129011875491310547126581
97623331044818386269515456334926366572897563400500
42846280183517070527831839425882145521227251250327
55121603546981200581762165212827652751691296897789
32238195734329339946437501907836945765883352399886
75506164965184775180738168837861091527357929701337
62177842752192623401942399639168044983993173312731
32924185707147349566916674687634660915035914677504
99518671430235219628894890102423325116913619626622
73267460800591547471830798392868535206946944540724
76841822524674417161514036427982273348055556214818
97142617910342598647204516893989422179826088076852
87783646182799346313767754307809363333018982642090
10848802521674670883215120185883543223812876952786
71329612474782464538636993009049310363619763878039
62184073572399794223406235393808339651327408011116
66627891981488087797941876876144230030984490851411
60661826293682836764744779239180335110989069790714
85786944089552990653640447425576083659976645795096
66024396409905389607120198219976047599490197230297
64913982680032973156037120041377903785566085089252
16730939319872750275468906903707539413042652315011
94809377245048795150954100921645863754710598436791
78639167021187492431995700641917969777599028300699
15368713711936614952811305876380278410754449733078
40789923115535562561142322423255033685442488917353
44889911501440648020369068063960672322193204149535
41503128880339536053299340368006977710650566631954
81234880673210146739058568557934581403627822703280
82616570773948327592232845941706525094512325230608
22918802058777319719839450180888072429661980811197
77158542502016545090413245809786882778948721859617
72107838435069186155435662884062257473692284509516
20849603980134001723930671666823555245252804609722
53503534226472524250874054075591789781264330331690";


            List<List<int>> nums;
            nums = new List<List<int>>();
            nums.Add(new List<int>());

            for (int i = 0; i < s.Length; i++)
            {
                int temp = -1;

                int.TryParse(s[i].ToString(), out temp);

                if (temp != 0)
                {
                    //nums.Add(s[i]);
                    nums[nums.Count - 1].Add(int.Parse(s[i].ToString()));
                    Console.Write(s[i]);
                }
                else if (s[i] == '\n')
                {
                    nums.Add(new List<int>());
                    Console.WriteLine();
                }
                else if (s[i] != '\r')
                {
                    nums[nums.Count - 1].Add(int.Parse(s[i].ToString()));
                    Console.Write(s[i]);
                }
            }

            int digits = 50;
            List<int> sums = new List<int>();
            for (int i = 0; i < digits; i++)
            {
                for (int j = 0; j < nums.Count; j++)
                {
                    c += (int)(nums[j][nums[j].Count - (i + 1)]);

                }
                sums.Add(c);
                c = 0;
            }


            Stack<int> bigSum = new Stack<int>();
            for (int i = 0; i < sums.Count; i++)
            {

                int temp = sums[i];
                //for (int j = i; j >= 0; j--)
                //{
                //    temp +=(int)( sums[j] / Math.Pow(10, i - j));
                //}
                if (i > 0)
                {
                    temp = sums[i] + sums[i - 1] / 10;
                    sums[i] = temp;
                }
                //    else
                //     bigSum.Push(sums[i] % 10);
                if (i == sums.Count - 1)
                {
                    while (temp > 0)
                    {
                        bigSum.Push(temp % 10);
                        temp /= 10;
                    }

                }
                else

                    bigSum.Push(temp % 10);

            }
            Console.WriteLine();
            Console.WriteLine();
            while (bigSum.Count > 0)
                Console.Write(bigSum.Pop());
        }
        public static long CollatzCount(long num)
        {
            long c = 1;
            while (num != 1)
            {
                if (num % 2 == 0)
                    num /= 2;
                else
                    num = num * 3 + 1;
                c++;
            }
            return c;
        }
        public static long move(int i, int j,int lines,int columns)
        {
            if (i == lines - 1 && j == columns - 1)
                return 1;
            if (j == i)
                return move(i, j + 1, lines, columns)*2 ;
            
            //if (i == 0 && j == 0)
         //       return move(i, j + 1, lines, columns);
            if (j == columns - 1)
                return move(i + 1, j, lines, columns) ;

            return move(i + 1, j, lines, columns)  + move(i, j + 1, lines, columns);
        }
        public static int DigitSum(long num)
        {
            int sum = 0;
            while (num > 0)
            {
                sum += (int)(num % 10);
                num /= 10;
            }
            return sum;
        }
        public static int DigitCount(int num)
        {
            if (num == 0)
                return 1;
            return Convert.ToInt32(Math.Floor(Math.Log10(num)))+1;
        }
        public static int DigitCount(long num)
        {
            if (num == 0)
                return 1;
            return Convert.ToInt32(Math.Floor(Math.Log10(num))) + 1;
        }
        public static string SinglesToWords(int num)
        {
            switch (num)
            {
                case 1:
                    return "one ";
                    
                case 2:
                    return "two ";
                case 3:
                    return "three ";
                case 4:
                    return "four ";
                case 5:
                    return "five ";
                case 6:
                    return "six ";
                case 7:
                    return "seven ";

                case 8:
                    return "eight ";
                case 9:
                    return "nine ";
                case 10:
                    return "ten ";
                case 11:
                    return "eleven ";
                case 12:
                    return "twelve ";
                case 13:
                    return "thirteen ";
                case 14:
                    return "fourteen ";
                case 15:
                    return "fifteen ";
                case 16:
                    return "sixteen ";
                case 17:
                    return "seventeen ";
                case 18:
                    return "eighteen ";
                case 19:
                    return "nineteen ";  
                case 20:
                    return "twenty ";
                case 30:
                    return "thirty ";
                case 40:
                    return "forty ";
                case 50:
                    return "fifty ";
                case 60:
                    return "sixty ";
                case 70:
                    return "seventy ";
                case 80:
                    return "eighty ";
                case 90:
                    return "ninety ";
            }
            return "";
        }
        public static string NumToWords(int num)
        {
            bool and = false;
            int digits = (int)Math.Log10(num)+1;
            string stringed=num.ToString();
            string word = "";
            for (int i = digits-1; i >=0; i--)
            {
                int digit=0;
                int temp=num;
                for (int j = 0; j < i; j++)
                {
                    temp /= 10;
                }
                digit=temp%10;
                if (digit == 0)
                    continue;
                switch (i)
                {
                    case 3:
                        word = word + SinglesToWords(digit) + "thousand ";
                        break;
                    case 2: //Hundreds
                          word = word + SinglesToWords(digit) + "hundred ";
                            and = true;
                        
                        break;
                    case 1://Tens

                        
                            if (and)
                            {
                                word = word + "and ";
                                and = false;
                            }
                            if (digit == 1)
                            {
                                word = word + SinglesToWords(digit * 10 + num % 10);
                                i -= 2;
                            }
                            else
                                word = word  + SinglesToWords(digit * 10);
                        
                            break;
                        
                    case 0: //Ones
                        
                            if (and)
                            {
                                word = word + "and ";
                                and = false;
                            }
                            word = word  + SinglesToWords(digit);
                        
                            break;
                }
            }
            return word;
        }
        public static void addToTenAbove(int j,List<int> digits)
        {
            if (digits[j] > 9)
            {
                if (j == digits.Count - 1)
                    digits.Add(0);

                digits[j + 1] += digits[j] / 10;
                digits[j] = digits[j] % 10;
                addToTenAbove(j + 1, digits);
            }
        }
        public static void Amicable()
        {
            int sum = 0;
            for (int i = 0; i < 10000; i++)
            {
                int j = (int)DivSum(i);

                if (j > i)
                    if (DivSum(j) == i)
                    {
                        Console.WriteLine("{0},{1}", i, j);
                        sum += i + j;
                    }


            }
            Console.WriteLine(sum);
        }
        public static int LetterLoc(char c)
        {

            return (int)c-64;
        }
        public static int NameScore(string name, int index)
        {
            int score = 0;
            for (int i = 0; i < name.Length; i++)
            {
                score += LetterLoc(name[i]) * index;
            }

            return score;
        }
        public static void Spiral()
        {
            int[,] nums = new int[1001, 1001];
            int i = nums.GetLength(1) / 2;
            int j = nums.GetLength(0) / 2;
            int c = 1;
            int d = 1;
            bool flag = true;
            while (nums[0, nums.GetLength(1) - 1] == 0)
            {
                for (int k = 0; k < d; k++)
                {
                    nums[i, j] = c;
                    c++;
                    if (flag)
                        j++;
                    else
                        j--;
                }
                if (nums[0, nums.GetLength(1) - 1] != 0)
                    break;
                for (int k = 0; k < d; k++)
                {
                    nums[i, j] = c;
                    if (flag)
                        i++;
                    else
                        i--;
                    c++;
                }
                flag = !flag;
                d++;
            }
            int sum = 0;
            for (int k = 0; k < nums.GetLength(0); k++)
            {
                sum += nums[k, k];
                if (nums.GetLength(0) - 1 - k != k)
                    sum += nums[nums.GetLength(0) - 1 - k, k];
            }
            Console.WriteLine(sum);
        }
        public static int Factorial(int num)
        {
            int sum = 1;
            for (int i = 2; i <= num; i++)
            {
                sum *= i;
            }
            return sum;
        }
        public static bool isPentagon(int num)
        {
            double delta= 1-4*3*(-2*num);
            if(delta<0)
                return false;
            if (Math.Sqrt(delta) % 1 != 0)
                return false ;
            if (((1 + Math.Sqrt(delta)) / 6) % 1 != 0)
                return false;
           // Console.WriteLine((1 + Math.Sqrt(delta)) / 6);
           // return ((1 + Math.Sqrt(delta)) / 6);
            return true;
        }
        public static void minPentagon()
        {
            List<int> nums = new List<int>();

            int min = int.MaxValue;
            for (int i = 1; i < int.MaxValue; i++)
            {
                if (isPentagon(i))
                {
                    nums.Add(i);
                    for (int j = nums.Count - 2; j >= 0; j--)
                    {
                        int temp = i + nums[j];
                        if (isPentagon(temp))
                        {
                            //Console.WriteLine(i+"+"+nums[j]+"="+(i+nums[j]));
                            temp = Math.Abs(i - nums[j]);
                            if (isPentagon(temp))
                            {
                                if (temp < min)
                                {
                                    min = temp;
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine(min);
                                }
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }
                        }
                    }
                }
            }
            Console.WriteLine(min);
        }
        static int count = 0;
        public static List<int> permutations = new List<int>();
        public static void permutation(List<char> characters,string current)
        {
            if (characters.Count == 1)
            {
                int num = int.Parse(current + characters[0]);
                permutations.Add(num);
                //if (fuIsPrime(num))//For Pandigital Prime
                //    Console.WriteLine(num);
               // Console.WriteLine(current + characters[0]);
                //count++;
                //if(count==1000000)
                   // Console.WriteLine(current + characters[0]);
            }
            else
            for (int i = 0; i < characters.Count; i++)
            {
                string temp = current;
                temp = temp + characters[i];
                List<char> edited = new List<char>(characters);
                edited.Remove(characters[i]);
                permutation(edited, temp);
            }
            
            
        }
        public static void Goldbuch()
        {//46
            for (int i = 1; i < int.MaxValue; i += 2)
            {
                if (!fuIsPrime(i))
                {
                    bool flag = false;
                    for (int j = i - 2; j >= 1; j -= 2)
                    {
                        if (fuIsPrime(j))
                        {
                            if (Math.Sqrt((i - j) / 2) % 1 == 0)
                            {
                                flag = true;
                                // Console.WriteLine("{0} = {1} +2*{2}^2", i, j, Math.Sqrt((i - j) / 2));
                                break;
                            }
                        }

                    }
                    if (!flag)
                    {
                        Console.WriteLine(i);
                        break;
                    }
                }
            }
        }
        public static bool isPandigital(int num)
        {
            int[] counts = new int[(int)Math.Log10(num)+1];
            while (num > 0)
            {
                int dig = num % 10;
                try
                {
                    if (counts[dig - 1] == 1)
                        return false;
                    else
                        counts[dig - 1]++;
                    num /= 10;
                }
                catch (IndexOutOfRangeException e)
                {

                    return false;
                }
                
            }
            return true;
        }
        public static bool isPermutationOf(int num1, int num2)
        {
            if ((int)Math.Log10(num1) + 1 != (int)Math.Log10(num2) + 1)
                return false;
            List<char> digits = num2.ToString().ToCharArray().ToList<char>();
            while (num1 > 0)
            {
                int dig = num1 % 10;
                if (digits.Contains(char.Parse(dig.ToString())))
                    digits.Remove(char.Parse(dig.ToString()));
                else
                    return false;

                num1 /= 10;     
            }
            return true;
        }
        public static void PrimePermutation()
        {
            for (int i = 1000; i < 10000; i++)//49
            {
                if (fuIsPrime(i))
                {
                    permutations = new List<int>();
                    for (int j = 1; i + j < 10000; j++)
                    {
                        int temp = i + j;
                        if (isPermutationOf(i, temp) && fuIsPrime(temp))
                        {
                            if (isPermutationOf(temp, temp + j) && fuIsPrime(temp + j))
                                Console.WriteLine("{0} {1} {2} ~{3}", i, temp, temp + j, j);
                        }
                    }
                }
            }
        }
        public static List<int> BigSum(List<int> num1, List<int> num2)
        {
            //int digits = 50;
            List<int> sum = new List<int>();
            List<int> bigger = new List<int>();
            List<int> smaller = new List<int>();
       
            if (num1.Count > num2.Count)
            {
                bigger = num1;
                smaller = num2;
            }
            else
            {
                smaller = num1;
                bigger = num2;
            }
            for (int i = 0; i < bigger.Count; i++)
            {
                int dig = bigger[i];
                int dig2 = 0;
                if (i < smaller.Count)
                {
                    dig2 = smaller[i];
                }
                if (i >= sum.Count)
                    sum.Add(0);
                   sum[i] += dig + dig2;
              
                addToTenAbove(i, sum);

            }
            return sum;
        }
        public static void selfPowers()
        {
            //48
            List<List<int>> allSums = new List<List<int>>();
            for (int k = 1; k < 1000; k++)
            {


                List<int> digits = new List<int>();
                int sum = 0;

                digits.Add(1);

                for (int i = 0; i < k; i++)
                {
                    //int lim = digits.Count;
                    for (int j = digits.Count - 1; j >= 0; j--)
                    {


                        digits[j] *= k;
                        addToTenAbove(j, digits);
                        //if (digits[j] > 9)
                        //{

                        //    digits[j] = digits[j] % 10;
                        //    if (j == digits.Count - 1)
                        //        digits.Add(0);

                        //    digits[j + 1]++;




                        //}

                    }
                }



                //for (int i = digits.Count - 1; i >= 0; i--)
                //{
                //    //Console.Write(digits[i]);
                //    sum += digits[i];
                //}

                //Console.WriteLine();
                //Console.WriteLine(sum);
                allSums.Add(digits);
            }
            List<int> bigsum = new List<int>();
            for (int i = 0; i < allSums.Count; i++)
            {
                bigsum = BigSum(bigsum, allSums[i]);
            }
            for (int i = bigsum.Count - 1; i >= 0; i--)
            {
                Console.Write(bigsum[i]);
            }
        }
        public static List<int> PrimeFactors(int num)
        {
            List<int> Factors = new List<int>();
            int temp = num;
            int div = 2;
            while (num != 1)
            {
                if (num % div == 0)
                {
                    if (!Factors.Contains(div))
                        Factors.Add(div);
                    num /= div;
                }
                else
                    div++;
            }
            return Factors;
        }
        public static void DistinctPrimes()
        {//47
            List<int> consecutive = new List<int>();
            int lim = 4;
            for (int i = 2; i < int.MaxValue; i++)
            {
                if (PrimeFactors(i).Count == lim)
                {
                    consecutive.Add(i);
                    if (consecutive.Count == lim)
                    {
                        for (int l = 0; l < consecutive.Count; l++)
                        {
                            Console.WriteLine(consecutive[l]);

                        }
                        break;
                    }
                }
                else
                    consecutive.Clear();
            }
        }
        public static bool InSortedList(int num, List<int> nums)
        {
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] > num)
                    return false;

                if (nums[i] == num)
                    return true;
            }
            return false;
        }
        public static void TriPentaHexa()
        {
            //for (double i = 1; i < double.MaxValue; i++)
            //{
            //    if (i * (71.0 / 41.0) % 1 == 0)
            //    {
            //        int k=(int)( i * (71.0 / 41.0))+1;
            //        long tri=k*(k+1)/2;

            //        long penta =(int)( (i+1)*(3*(i+1)-1)/2);
            //        if(tri==penta)
            //            Console.WriteLine(i);
            //    }
            //}
            List<long> penta = new List<long>();
            penta.Add(1);
            // List<long> hexa = new List<long>();


            int l = 1;
            for (int i = 1; i < int.MaxValue; i += 2)
            {

                //List<int> indexes = new List<int>();
                bool loc = false;
                long tri = i * (i + 1) / 2;

                while (penta[l - 1] < tri)
                {
                    l++;
                    if (l > i)
                    {
                        Console.WriteLine();
                    }
                    long pent = (l * (3 * l - 1) / 2);
                    penta.Add(pent);
                }
                //  hexa.Add(i * (2 * i - 1));
                for (int k = 1; k <= penta.Count; k++)
                {
                    //if (!loc)
                    //{
                    //    if (hexa[k-1] > tri)
                    //        break;
                    //    else if (hexa[k-1] == tri)
                    //    {
                    //        loc = true;
                    //        hexloc = k;
                    //    }
                    //}
                    if (penta[k - 1] == tri)
                    {
                        Console.WriteLine("{0} {1} {2}", i, k, i / 2 + 1);

                    }
                }
            }
        }
        public static int GetFirstDigit(decimal num)
        {
            int i = (int)(num % 10);
            return i;
        }
        public static int GetRecurringCount(decimal num)
        {

            while (num % 10 != 0)
            {
                List<int> chain = new List<int>();
                decimal temp = num;

                while (temp % 1 != 0)
                {
                    temp = temp * 10 % 10;
                    int dig = (int)temp % 10;
                    if (chain.Count > 0)
                    {
                        if (dig == chain[0])
                        {
                            decimal tempNum = temp;


                            for (int i = 0; i < chain.Count + 1; i++)
                            {
                                if (i == chain.Count)
                                    return chain.Count;
                                if (chain[i] != GetFirstDigit(tempNum))
                                    break;
                                tempNum *= 10;
                            }
                        }
                    }
                    chain.Add((int)(temp % 10));

                }
                num = num * 10 % 10;
            }
            return 0;
        }
        public static void distinctPowers()
        {
            int count = 0;
            int limit = 100;
            List<double> numbers = new List<double>();
            for (int a = 2; a <= limit; a++)
            {
                for (int b = 2; b <= limit; b++)
                {

                    bool dontAdd = false;
                    if (Math.Pow(a, b) == Math.Pow(16, 51))
                    {
                        int asd = 0;
                    }
                    for (int i = 2; i < a; i++)
                    {



                        double tempo = (Math.Log(a, i)) * b;
                        int tempB = Convert.ToInt16(Math.Round(tempo));
                        if (Math.Abs(tempB - tempo) < 0.0000001)
                        {

                            if (i < a && tempB <= limit)
                            {
                                dontAdd = true;
                                Console.WriteLine(a + " " + b);
                                break;
                            }
                        }


                    }
                    if (!dontAdd)
                    {
                        count++;
                        if (numbers.Contains(Math.Pow(a, b)))
                        {
                            double sda = Math.Pow(a, b);
                        }
                        numbers.Add(Math.Pow(a, b));
                    }
                }
            }
            numbers.Sort();
            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] == numbers[i - 1])
                    Console.WriteLine(numbers[i]);
            }

            Console.WriteLine(count);
        }
        public static int countCoinsWays(int sum,int dest,List<int> coins)
        {
            if (sum > dest)
            {
                //Console.ForegroundColor = ConsoleColor.Red;
                //Console.WriteLine(sum);
                //Console.ForegroundColor = ConsoleColor.Gray;
                return 0;
               
            }
            if (sum == dest)
            {
                //Console.ForegroundColor = ConsoleColor.Green;
                //Console.WriteLine(sum);
                //Console.ForegroundColor = ConsoleColor.Gray;
                return 1;
            }
            int count=0;
            foreach (int coin in coins)
            {
                //Console.WriteLine(coin+" ");
                count += countCoinsWays(sum+coin,dest,coins);
            }
            return count;

        }
        public static void identityPandigital()
        {
            List<int> nums = new List<int>();
            for (int i = 100; i < 10000; i++)
            {
                for (int j = 1; j < 1000; j++)
                {
                    if (i == 186 && j == 39)
                    {
                        int asdas = 0;
                    }
                    int multiplicand = i;
                    int multiplier = j;
                    int identity = i * j;
                    int[] counts = new int[9];

                    int sum = DigitCount(multiplicand);
                    sum += DigitCount(multiplier);
                    sum += DigitCount(identity);
                    if (sum == 9)
                    {
                        bool stop = false;
                        while (multiplicand > 0)
                        {
                            int dig = GetFirstDigit(multiplicand);

                            if (dig == 0 || counts[dig - 1] > 0)
                            {
                                stop = true;
                                break;
                            }
                            counts[dig - 1]++;
                            multiplicand /= 10;
                        }
                        if (!stop)
                        {
                            while (multiplier > 0)
                            {
                                int dig = GetFirstDigit(multiplier);
                                if (dig == 0 || counts[dig - 1] > 0)
                                {
                                    stop = true;
                                    break;
                                }
                                counts[dig - 1]++;
                                multiplier /= 10;
                            }
                        }
                        if (!stop)
                        {
                            while (identity > 0)
                            {
                                int dig = GetFirstDigit(identity);
                                if (dig == 0 || counts[dig - 1] > 0)
                                {
                                    stop = true;
                                    break;
                                }
                                counts[dig - 1]++;
                                identity /= 10;
                            }
                        }
                        if (!stop)
                        {
                            if (!nums.Contains(i * j))
                                nums.Add(i * j);
                            Console.WriteLine(i + " * " + j + " = " + i * j);
                        }
                    }
                    else if (sum > 9)
                        break;
                }
            }
            Console.WriteLine(nums.Sum());
        }

        public static List<int> GetCircularNumbers(int num)
        {
            List<int> numbers = new List<int>();
            int length = DigitCount(num);
            int temp = num;
            for (int i = 0; i < length-1; i++)
            {

                int dig = GetFirstDigit(temp);
                temp /= 10;
                temp+=dig * (int)Math.Pow(10, length-1);
                numbers.Add(temp);
            }
            return numbers;
        }
        public void DoublePalindrom()
        {
            int sum = 0;
            for (int i = 0; i < 1000000; i++)
            {
                if (isPalindrom(i))
                {
                    string bin = GetIntBinaryStringRemoveZeros(i);
                    char[] op = bin.ToCharArray();
                    Array.Reverse(op);
                    string reversed = new string(op);
                    if (bin.Equals(reversed))
                    {
                        Console.WriteLine(i + "  " + bin);
                        sum += i;
                    }
                }
            }
            Console.WriteLine(sum);
        }
        public void PandigitalBiggest()
        {
            for (int i = 1; i < 10000; i++)
            {
                int[] counts = new int[9];
                int digitsCount = 0;
                bool isPandigital = true;
                string cont = "";
                for (int j = 1; j < 100; j++)
                {

                    if (digitsCount == 9)
                        break;
                    int num = i * j;
                    int digCount = DigitCount(num);
                    digitsCount += digCount;
                    cont += num;
                    if (digitsCount > 9)
                    {
                        isPandigital = false;
                        break;
                    }
                    //if (j == 1 && digCount * j > 9)
                    //{
                    //    isPandigital = false;
                    //    break;
                    //}
                    //else
                    {
                        while (num > 0)
                        {
                            int dig = GetFirstDigit(num);
                            if (dig == 0 || counts[dig - 1] > 0)
                            {
                                isPandigital = false;
                                break;
                            }
                            else
                                counts[dig - 1]++;
                            num /= 10;
                        }
                    }

                    if (!isPandigital)
                        break;
                }
                if (digitsCount == 9 && isPandigital)
                    Console.WriteLine(i + "    " + cont);
            }
        }
        public static bool numberIsCyclical(int firstNum,List<Func<int, bool>> actions, int num)
        {
            if (actions.Count == 0 && num == firstNum)
                return true;

       
     
            foreach (Func<int, bool> finction in actions)
            {
    
                    if (finction(num))
                    {
                        int temp = num % 100 * 100;
                        if (DigitCount(temp) != DigitCount(firstNum))
                            return false;
                        List<Func<int, bool>> newActions = new List<Func<int, bool>>(actions);
                        newActions.Remove(finction);
                        for (int i = 1; i < 100; i++)
                        {
                            temp++;
                            if (numberIsCyclical(firstNum, newActions, temp))
                            {
                                Console.WriteLine(num + " - " + finction.Method.Name);
                                return true;
                            }
                     
                        }
                    }
               
            }
            return false;


        }
        public static void CyclonicalHexlets()
        {
             List<Func<int, bool>> actions = new List<Func<int, bool>>();


             for (int i = 1000; i < 10000; i++)
             {
                 actions.Clear();
                 int num = i;

                 actions.Add(IsTriangle);
                 actions.Add(IsSquare);
                 actions.Add(IsPentagonal);
                 actions.Add(IsHexagonal);

                 actions.Add(IsHeptagonal);
                 actions.Add(IsOctagonal);
                 int[] counts = new int[actions.Count];

                 if (numberIsCyclical(i, actions, i)) Console.WriteLine();
             }
        }
        private static long gcd2(long x, long y)
        {
            while (x * y != 0)
            {
                if (x >= y) x = x % y;
                else y = y % x;
            }
            return (x + y);
        }

        //public static int P(int n)
        //{
        //    if (n == 1)
        //        return 1;

        //}
        public static void powerfulDigits()
        {
            int count = 0;

            for (int i = 1; i < 10; i++)
            {
                for (int digits = 1; digits < 100; digits++)
                {
                    double bse = Math.Floor(Math.Log(Math.Pow(10, digits - 1), i));
                    if (bse >= digits - 1 && bse < digits)
                    {
                        Console.WriteLine("{0}^{1} ~ {1}", i, bse + 1);
                        count++;
                    }
                    else
                        break;
                }
            }

            Console.WriteLine(count + 1);
            Console.ReadLine();
        }
        public static long[] fractionaddition(int adder, int numerator, int denomator, int expantion, int limit)
        {
            if (limit == expantion)
            {
                return new long[] { adder * denomator + numerator, denomator };
            }
            else
            {
                long[] denominator = fractionaddition(denomator, 1, 2, expantion + 1, limit);
                long newNumerator = denominator[1];
                long newDenominator = denominator[0];

                long a = adder * newDenominator + newNumerator;
                long b = newDenominator;

                if (DigitCount(b) >= 10)
                {
                    a /= 10;
                    b /= 10;
                }
                return new long[] { a, b };
            }
        }
        public static void squre2()
        {
            int count = 0;
            for (int i = 1; i < 1001; i++)
            {
                long[] frac = fractionaddition(1, 1, 2, 1, i);
                Console.WriteLine("{2} : {0}/{1}", frac[0], frac[1], i);
                if (gcd2(frac[0], frac[1]) != 1)
                {
                    int c = 0;
                    c = 5;
                    bool sadasd = false;
                    if (sadasd)
                    {

                    }
                }
                if (DigitCount(frac[0]) > DigitCount(frac[1]))
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }
        public static bool isLychrel(int num)
        {
            BigInteger b = num;
            int iteration = 0;
            while (!isPalindrom(b))
            {
                iteration++;
                if (iteration == 50)
                    return true;
                b += ReverseNumber(b);
            }
            return false;
        }
        public static void permutationMultiply()
        {
            int i = 6;

            while (true)
            {
                Console.WriteLine(i);
                bool flag = true;
                int totalMultiple = 6;
                int num = i;
                int[] counts = new int[10];

                while (num > 0)
                {
                    counts[GetFirstDigit(num)]++;
                    num /= 10;
                }
                for (int h = totalMultiple - 1; h > 0; h--)
                {
                    int[] NewCounts = new int[10];
                    num = (i * h) / totalMultiple;
                    //while (num > 0)
                    //{
                    //    NewCounts[GetFirstDigit(num)]++;
                    //    num /= 10;
                    //}
                    //if (!Enumerable.SequenceEqual(counts, NewCounts))
                    //{
                    //    flag = false;
                    //    break;
                    //}
                    if (!isPermutationOf(i, num))
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                    break;
                i += 6;

            }
            Console.WriteLine(i);
        }
    
        public static int WordCharSum(string word)
        {
            int sum = 0;

            foreach (char letter in word)
            {
                sum += charPosition(letter);

            }
            return sum;
        }
        public static int charPosition(char a)
        {
            return (int)a - (int)('A') + 1;
        }
        public static bool flag = false;
        public static bool IsTriangle(int num)
        {

            double answer = SolveQuadratic(1, 1, -2 * num);
            if (answer > 0 && answer % 1 == 0)
                return flag = true;
            else
                return flag = false;
        }
        public static bool IsSquare(int num)
        {
            return flag = Math.Sqrt(num) % 1 == 0;
        }
        public static bool IsPentagonal(int num)
        {

            double answer = SolveQuadratic(3, -1, -2 * num);
            if (answer > 0 && answer % 1 == 0)
                return flag = true;
            else
                return flag = false;
        }
        public static bool IsHexagonal(int num)
        {

            double answer = SolveQuadratic(2, -1, -num);
            if (answer > 0 && answer % 1 == 0)
                return flag = true;
            else
                return flag = false;
        }
        public static bool IsHeptagonal(int num)
        {

            double answer = SolveQuadratic(5, -3, -2 * num);
            if (answer > 0 && answer % 1 == 0)
                return flag = true;
            else
                return flag = false;
        }
        public static bool IsOctagonal(int num)
        {

            double answer = SolveQuadratic(3, -2, -num);
            if (answer > 0 && answer % 1 == 0)
                return flag = true;
            else
                return flag = false;
        }
        public static double SolveQuadratic(double a, double b, double c)
        {

            double sqrtpart = b * b - 4 * a * c;

            double x, x1, x2, img;

            if (sqrtpart > 0)
            {

                x1 = (-b + System.Math.Sqrt(sqrtpart)) / (2 * a);

                x2 = (-b - System.Math.Sqrt(sqrtpart)) / (2 * a);

                //Console.WriteLine("Two Real Solutions: {0,8:f4} or  {1,8:f4}", x1, x2);
                return Math.Max(x1, x2);
            }

            //else if (sqrtpart < 0)
            //{

            //    sqrtpart = -sqrtpart;

            //    x = -b / (2 * a);

            //    img = System.Math.Sqrt(sqrtpart) / (2 * a);

            //    Console.WriteLine("Two Imaginary Solutions: {0,8:f4} + {1,8:f4} i or {2,8:f4} + {3,8:f4} i", x, img, x, img);

            //}

            else
            {

                x = (-b + System.Math.Sqrt(sqrtpart)) / (2 * a);

                //Console.WriteLine("One Real Solution: {0,8:f4}", x);
                return x;
            }

        }
        static string GetIntBinaryStringRemoveZeros(int n)
        {
            char[] b = new char[32];
            int pos = 31;
            int i = 0;

            while (i < 32)
            {
                if ((n & (1 << i)) != 0)
                {
                    b[pos] = '1';
                }
                else
                {
                    b[pos] = '0';
                }
                pos--;
                i++;
            }
            return new string(b).TrimStart('0');
        }
   
        public static void countRectangles(int a, int b,List<Rectangle> countedRectangles)
        {
            Rectangle rect = new Rectangle(a, b);
            if (countedRectangles.Contains(rect))
                return;
        
                countedRectangles.Add(new Rectangle(a, b));
              

            if (a > 1)
                countRectangles(a - 1, b,countedRectangles);
            if (b > 1)
                countRectangles(a, b - 1,countedRectangles);
          
        }
        public static void printRectangle(Rectangle rect)
        {
            Console.WriteLine("{0} X {1}",rect.Length,rect.Width);
            rect.Width =(int)(rect.Width* 2);
            for (int i = 0; i < rect.Length+2; i++)
            {
                
                for (int j = 0; j < rect.Width+2; j++)
                {
                    if (i == 0)
                    {
                        if (j == 0)
                            Console.Write("┌");
                        else  if(j==rect.Width+1)
                                Console.Write("┐");
                        else
                            Console.Write("─");
                    }
                    else if (i == rect.Length + 1)
                    {
                        if (j == 0)
                            Console.Write("└");
                        else if (j == rect.Width + 1)
                            Console.Write("┘");
                        else
                            Console.Write("─");
                    }
                    else
                    {
                         if (j == rect.Width + 1||j==0)
                             Console.Write("│");
                        else Console.Write(" ");
                    }

                }
                    Console.WriteLine();
            }
        }
        public static void problem85()
        {
            List<Rectangle> availabelRectangles = new List<Rectangle>();
            // int a = 1;
            int b = 1;
            int limit = 2000000;
            Rectangle candidGrid = new Rectangle(1, 1);
            int diff = int.MaxValue;
            for (int a = 1; ; a++)
            {

                countRectangles(a, b, availabelRectangles);

                int rectCountsSum = 0;
                foreach (Rectangle rect in availabelRectangles)
                {
                    rectCountsSum += ((a - (rect.Width - 1)) * (b - (rect.Length - 1)));
                    //  printRectangle(rect);
                }
                if (Math.Abs(rectCountsSum - limit) < diff)
                {
                    diff = Math.Abs(rectCountsSum - limit);
                    candidGrid = new Rectangle(a, b);



                    Console.WriteLine(a + " X " + b + "  " + rectCountsSum + " Rectangles");

                }
                if (rectCountsSum >= limit)
                {
                    Console.WriteLine(a + " X " + b + "  " + rectCountsSum + " Rectangles, Broke");
                    if (b >= a)
                        break;
                    b++;
                    a = 1;

                    availabelRectangles = new List<Rectangle>();
                }
            }
            Console.WriteLine("{0}X{1} Grid with a diff of {2} and an are of {3}", candidGrid.Length, candidGrid.Width, diff, candidGrid.Length * candidGrid.Width);
        }
        public static void problem64()
        {
            int count = 0;

            for (double i = 1; i<= 10000; i++)
            {
             
               // Console.Write(i+"  ");
                double sq = Math.Sqrt(i);
                if (sq % 1 != 0)
                {
                   // int origIntegerPart = 0;
                   // int origNominator = 0;
                    int origDenominatorAddition = 0;

                    bool flag = true;
                    int integerPart = (int)(sq);
                    int nominator = 1;
                    int denominatorAddition = -integerPart;
                    int limit = int.MaxValue,iterator=0;
                    List<int> seq = null ;
                    while (flag)
                    {
                        
                       // Console.Write(integerPart);
                        if (origDenominatorAddition == denominatorAddition && nominator==1)
                            flag = false;
                        if (seq == null)
                        {
                            seq = new List<int>();
                            origDenominatorAddition = denominatorAddition;
                        }
                        else
                            seq.Add(integerPart);
                        //else
                        //{
                        //    if (seq.Count > 0)
                        //    {

                        //        if (iterator != 0 && integerPart == seq[iterator])
                        //        {

                        //            iterator++;
                        //        }
                        //        else if (integerPart == seq[0])
                        //        {
                        //            limit = seq.Count;
                        //            iterator = 1;
                        //        }
                        //        else
                        //        {
                        //            iterator = 0;
                        //            limit = int.MaxValue;
                        //        }
                        //    }
                        //    if (iterator == limit)
                        //    {
                        //        flag = false;
                        //    }
                        //    seq.Add(integerPart);
                        //}
                                             
                        int nominatorMultiplier = nominator;
                     
                        //int nominatorAddition = -denominatorAddition;
                        int newDenominator = (int)i - (denominatorAddition * denominatorAddition);

                        int k = (int)gcd2(nominatorMultiplier, newDenominator);
                        while (k != 1)
                        {
                            nominatorMultiplier /= k;
                            newDenominator /= k;
                            k = (int)gcd2(nominatorMultiplier, newDenominator);
                        }

                        nominator = newDenominator;
                           denominatorAddition = -denominatorAddition;
                        integerPart = (int)((nominatorMultiplier * (Math.Sqrt(i) + denominatorAddition)) / newDenominator);

                        denominatorAddition = denominatorAddition - integerPart * newDenominator;
                    }
                  //  Console.WriteLine(seq.Count);
                    if (seq.Count % 2 != 0)
                        count++;
                }
                else
                {
                  //  Console.WriteLine();
                }
            }
         
        }
        static void Main(string[] args)
        {
          
            Console.BufferHeight = 10000;
            DateTime start = DateTime.Now;
            long[] frac = fractionaddition(1, 1, , 1, 9);
            Console.WriteLine(frac[0]+"/"+frac[1]);
            TimeSpan t = DateTime.Now - start;
            Console.WriteLine(" in " + t.Milliseconds);
            //long sum=0;
            //long limit = 1000000000;
            //bool end = false;
            //for (long i = 2; !end; i++)
            //{
            //    long squre = i * i;

            //    long a = 3;
            //    long b = 8;
            //    long c = 4 * (1 - squre);

            //    decimal delta =(decimal) Math.Sqrt(b*b-4*a*c);
            //    if (delta % 1 == 0)
            //    {
            //        List<decimal> solutions = new List<decimal>();
            //        solutions.Add((b + delta) / (2 * a));
            //        solutions.Add((b - delta) / (2 * a));
            //        solutions.Add((-b + delta) / (2 * a));
            //        solutions.Add((-b - delta) / (2 * a));
            //        for (int k = 0; k < solutions.Count; k++)
            //        {
            //            decimal solution = solutions[k];
            //            if (solution > 0 && solution % 1 == 0 && solution % 2 == 0)
            //            {
            //                long triBase = (long)solution;
            //                long side = triBase - 1;
            //                if (k > 1)
            //                    side += 2;
            //                decimal perimeter = 2 * side + triBase;
                          
            //                if (perimeter > limit)
            //                {
            //                    end = true;
            //                    break;
            //                }
            //                Console.WriteLine("{0},{0},{1} {2}",side,triBase,perimeter);
            //                sum +=(long)perimeter;
            //            }
            //        }
                    
            //        //solution = (b - delta) / (2 * a);
            //        //if (solution > 0 && solution % 1 == 0)
            //        //{
            //        //    long triBase = (long)solution;
            //        //    long side = triBase - 1;
            //        //    sum += 2 * side + triBase;
            //        //}
            //        //solution = (-b + delta) / (2 * a);
            //        //if (solution > 0 && solution % 1 == 0)
            //        //{
            //        //    long triBase = (long)solution;
            //        //    long side = triBase + 1;
            //        //    sum += 2 * side + triBase;
            //        //}
            //        //solution = (-b - delta) / (2 * a);
            //        //if (solution > 0 && solution % 1 == 0)
            //        //{
            //        //    long triBase = (long)solution;
            //        //    long side = triBase + 1;
            //        //    sum += 2 * side + triBase;
            //        //}
            //    }
            //}
            //for (decimal i = 3; !end; i+=2)
            //{
            //    for (decimal j = i - 1; j < i + 2; j += 2)
            //    {

            //        decimal hight =(decimal) Math.Sqrt((double)((i * i) - ((j / 2) * (j / 2))));
            //        long perimeter = (long)(2 * i + j);
            //        if (perimeter > limit)
            //        {
            //            end = true;
            //            break;
                        
            //        }
            //        decimal area = (hight * j) / 2;
            //        if (hight % 1 == 0)
            //        {
                        
            //            Console.WriteLine(hight+" "+area);
            //            sum +=(long)perimeter;
            //        }
            //    }
            //}
            //Console.WriteLine(sum);
            Console.ReadLine();
          
        }
       
    }
}
