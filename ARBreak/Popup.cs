using System;
using System.Windows.Forms;
using System.Web.UI;
using mshtml;
using System.Threading.Tasks;

namespace ARBreak
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class Popup : Form
    {
        public string data { get; set; }

        private string API_key = "ogR9lgcbAsxxKut0DJd1KQVT63QU7IjY";
        private string base_url = "http://api.giphy.com/v1/gifs/search?";
        private int TotalImagesToRetrieve = 25;
        string[] breakArray = { "break", "fun", "party", "magic", "cat", "cute" };
        string[] workArray = { "work", "code", "job", "programming" };

        public Popup()
        {
            InitializeComponent();
        }

        private void addJavascriptCode()
        {
            try
            {
                Console.WriteLine(wbRandomImg.Document.All.Count);

                HtmlElement body = wbRandomImg.Document.Body;
                HtmlElement script = wbRandomImg.Document.CreateElement("script");
                IHTMLScriptElement element = (IHTMLScriptElement)script.DomElement;
                element.type = "text/javascript";
                element.text = @"function setRandomGiphy(query) {
                                 giphy = { api_key: '" + API_key + @"',
				                            base_url: '" + base_url + @"',
				                            limit: " + TotalImagesToRetrieve + @" };
		                        var parameters = 'q=' + query + '&api_key=' + giphy.api_key +
							                        '&limit=' + giphy.limit + '&offset=0&rating=G&lang=en';
							httpGet(giphy.base_url + parameters);
                        }
						function handler() {
							if(this.status == 200) {
								var img = new Image();
								var randomIndex = Math.floor(Math.random() * " + TotalImagesToRetrieve + @");
								var data = this.responseText;
								var jsonResponse = JSON.parse(data);
								img.src = jsonResponse.data[randomIndex].images.original.url;
								img.setAttribute('alt', 'something');
                                img.setAttribute('class', 'center-fit');
								document.getElementById('img-container').appendChild(img);
							} else {
								var label = document.createElement('label');
                                label.innerHTML = 'No Internet/Bad Image returned';
                                document.getElementById('img-container').appendChild(label);
                            }
                                        }
                        function httpGet(url)
                        {
                            var client = new XMLHttpRequest();
                            client.onload = handler;
                            client.open('GET', url);
                            client.send();
                        }
                            ";
                body.AppendChild(script);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Random rand = new Random();
            string[] array;
            if (data == "TIME_TO_WORK")
            {
                lblMessage.Text = "Get some work done!";
                array = workArray;
            }
            else
            {
                lblMessage.Text = "Its break time, take some rest!";
                array = breakArray;
            }
            int randIdx = rand.Next(0, array.Length);
            string searchKey = array[randIdx];
            callJSFunction("setRandomGiphy", searchKey);
        }

        private void callJSFunction(string name, params object[] args)
        {
            wbRandomImg.Document.InvokeScript(name, args);
        }

        private void OnLoad(object sender, EventArgs e)
        {
            wbRandomImg.AllowWebBrowserDrop = false;
            wbRandomImg.IsWebBrowserContextMenuEnabled = false;
            wbRandomImg.WebBrowserShortcutsEnabled = false;
            wbRandomImg.AllowNavigation = true;
            wbRandomImg.ObjectForScripting = this;
            wbRandomImg.IsAccessible = true;

            wbRandomImg.DocumentCompleted += WbRandomImg_DocumentCompleted;
            
            wbRandomImg.DocumentText = @"<!doctype html>
            <!-- saved from url=(0023)http://www.giphy.com/ -->
            <html>
            <head>
            <style>
            * {
                margin: 0;
                padding: 0;
                }
            .imgbox {
                display: grid;
                height: 100%;
            }
            .center-fit {
                max-width: 100%;
                max-height: 100vh;
                margin: auto;
            }
            </style>
            <title>Break!</title>
            <meta http-equiv='X-UA-Compatible' content='IE=10'>
            </head>
            <body bgcolor='#E0E0E0'>
                <div id='img-container'></div>
            </body>
            </html>";
        }

        private void Timeout()
        {
            System.Threading.Thread.Sleep(1000 * 10);
            this.btnConfirm.Invoke((MethodInvoker)delegate
            {
                this.btnConfirm.PerformClick();
            });
        }

        private void WbRandomImg_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            addJavascriptCode();
            new Task(Timeout).Start();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
