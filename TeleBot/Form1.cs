using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Telegram.Bot;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Message = Telegram.Bot.Types.Message;
using System.Windows.Forms;
using Telegram.Bot.Exceptions;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Net;
using System.Text.RegularExpressions;

namespace TeleBot
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		TelegramBotClient Botclient;
		private void Form1_Load(object sender, EventArgs e)
		{
			Botclient = new TelegramBotClient("Bot Token Here");
			StartReceiver();
		}
		public async Task StartReceiver()
		{
			var token = new CancellationTokenSource();
			var canceltoken = token.Token;
			var ReOpt = new ReceiverOptions { AllowedUpdates = { } };
			await Botclient.ReceiveAsync(OnMessage, ErrorMessage, ReOpt, canceltoken);
		}
		public async Task OnMessage(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
		{
			if (update.Message is Message message)
			{

				string[] couts = { "@" };
				string[] cser = message.Text.Split(couts, 1, StringSplitOptions.None);
				// I know this look weird but it dose the job
				// its reading and get any message that is send to the bot
				// and here you can send message as like this
				// await Botclient.SendTextMessageAsync(message.Chat.Id, "type ur message here");
				// and do what ever you want here


			}
		}
		public async Task ErrorMessage(ITelegramBotClient telegramBot, Exception e, CancellationToken cancellation)
		{
			if (e is ApiRequestException requestException)
			{
				await Botclient.SendTextMessageAsync("Error : ", e.Message.ToString());
			}

		}
	}
}
