using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Net;
using System.Collections.Specialized;

namespace gametrade
{
	internal class Program
	{
		private static void Main()
		{
			Program.Gen();
		}
		private static void Gen()
		{
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.WriteLine("");
			Console.WriteLine(" ######      ###    ##     ## ######## ######## ########     ###    ########  ######## ");
			Console.WriteLine("##    ##    ## ##   ###   ### ##          ##    ##     ##   ## ##   ##     ## ##       ");
			Console.WriteLine("##         ##   ##  #### #### ##          ##    ##     ##  ##   ##  ##     ## ##       ");
			Console.WriteLine("##   #### ##     ## ## ### ## ######      ##    ########  ##     ## ##     ## ######   ");
			Console.WriteLine("##    ##  ######### ##     ## ##          ##    ##   ##   ######### ##     ## ##       ");
			Console.WriteLine("##    ##  ##     ## ##     ## ##          ##    ##    ##  ##     ## ##     ## ##       ");
			Console.WriteLine(" ######   ##     ## ##     ## ########    ##    ##     ## ##     ## ########  ########\n\n\n\n\n");
			Console.WriteLine("作成したいアカウントの数を入力してください");
			string s = Console.ReadLine();
			int num = int.Parse(s);
			StreamWriter streamWriter = File.CreateText("C:\\Users\\" + Environment.UserName + "\\Downloads\\メアパス.txt");
			streamWriter.Close();
			for (int i = 0; i < num; i++)
			{
				Random random = new Random();
				int num2 = random.Next(1000);
				string str = Guid.NewGuid().ToString("N").Substring(0, 24);
				string text = "amadon" + str + num2.ToString();
				string text2 = text + "@mt2015.com";
				string text3 = "http://www.mytrashmail.com/myTrashMail_inbox.aspx?email=" + text;
				IWebDriver webDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
				webDriver.Navigate().GoToUrl("https://gametrade.jp/signup");
				Thread.Sleep(100);
				webDriver.FindElement(By.ClassName("email-btn-label")).Click();
				Thread.Sleep(100);
				webDriver.FindElement(By.Name("user[email]")).SendKeys(text2);
				Thread.Sleep(100);
				webDriver.FindElement(By.Name("user[password]")).SendKeys("112345ab");
				Thread.Sleep(100);
				webDriver.FindElement(By.Name("commit")).Click();
				Encoding encoding = Encoding.GetEncoding("Shift_JIS");
				StreamWriter streamWriter2 = new StreamWriter("C:\\Users\\" + Environment.UserName + "\\Downloads\\メアパス.txt", true, encoding);
				streamWriter2.WriteLine(text2 + " : 112345ab");
				streamWriter2.Close();
				webDriver.Quit();


				string webhook, webhookname, message;
				webhook = "your webhook";
				webhookname = "Gametrade公式";
				message = "```" + text2 + " : 112345ab" + "```";

				{
					Thread.Sleep(2000);
					Discord.Send(message, webhook, webhookname, "");
					Console.WriteLine(i.ToString(), Console.ForegroundColor = ConsoleColor.Cyan);
				}
				Console.WriteLine("何かキーを押して下さい。");
				Console.ReadKey();
			}
		}

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public class Discord
		{
			public class Http
			{
				public static byte[] Post(string url, NameValueCollection pairs)
				{
					using (WebClient webClient = new WebClient())
						return webClient.UploadValues(url, pairs);
				}
			}
			public static void Send(string content, string webHookUrl, string username, string avatarUrl)
			{
				Http.Post(webHookUrl, new NameValueCollection()
			{
				{
					"content", content
				},

				{
					"username", username
				},

				{
					"avatar_url", avatarUrl
				}

			});

			}
			
		}
	}
}



