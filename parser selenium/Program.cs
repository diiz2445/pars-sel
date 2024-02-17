using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

internal class Program
{
    private static void Main(string[] args)
    {

        IWebDriver driver = new EdgeDriver();
        driver.Url = "https://buff.163.com/goods/779289";



        List<IWebElement> quality = driver.FindElements(By.XPath("//*[@id=\"relative-goods\"]/div/a")).ToList();


        foreach (IWebElement inf in quality)
        {
            string[] a = inf.Text.ToString().Split(' ', '.');
            Console.WriteLine(inf.Text);
            Console.WriteLine("\n\n\n" + a);
            int k = 0;
            //adada
            double c = 0;
            bool flag = true;
            for (int i = 0; i < a.Length; i++)
            {
                if (int.TryParse(a[i], out k))
                {
                    if (flag)
                    {
                        c += k;
                        flag = false;
                    }
                    else
                        if (k < 10) c += (k / 10.0);
                    else c += k / 100.0;
                    Console.WriteLine(c);
                }
            }
        }

        Console.WriteLine();
        driver.Close();
        Console.ReadLine();
    }
}