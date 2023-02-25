using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Charlotte.Commons;
using Charlotte.Utilities;

namespace Charlotte.Tests
{
	public class Test0001
	{
		// 顧客情報
		public class CustomerInfo
		{
			public int CustomerId;       // 顧客ID
			public string FirstName;     // 姓
			public string LastName;      // 名
			public string Email;         // メールアドレス
			public string PhoneNumber;   // 電話番号
			public string Address;       // 住所
			//public string City;          // 市区町村
			//public string State;         // 都道府県
			//public string Country;       // 国名
			public string PostalCode;    // 郵便番号
		}

		private List<CustomerInfo> Customers;

		private void CreateCustomers()
		{
			const int RECORD_COUNT = 1000000;

			string[] FIRST_NAMES =
				new string[] { "陽菜", "蓮", "蒼空", "結菜", "颯太", "優花", "樹", "心愛", "悠真", "美羽", "太一", "美咲", "大翔", "彩花", "翔太", "千尋", "悠希", "琉花", "大和", "莉子", "翼", "桃子", "颯", "理央", "優希", "悠斗", "瑠菜", "慎太郎", "陽翔", "夏希", "瑞希", "大輝", "萌", "颯人", "愛菜", "智也", "綾音", "遥斗", "彩乃", "健太", "舞", "悠里", "拓海", "朱音", "龍太郎", "杏", "匠", "亜希", "圭太", "由菜", "悠", "海斗", "和馬", "愛梨", "拓真", "沙耶香", "優", "瑛太", "樹里", "翔", "莉緒", "尚輝", "葵", "亮太", "桜子", "雄大", "美和", "隆太", "柚希", "隼人", "恵", "拓也", "美優", "祐介", "奈緒美", "健", "希望", "翔平", "菜々子", "晃平", "未来", "琴音", "直樹", "真琴", "直人", "彩香", "亜衣", "智之", "菜月", "祐輔", "朋美", "瑠璃", "浩太朗", "柚葉", "健司", "由紀", "孝太郎", "慎之介", "鈴音", "祐樹", "愛梨沙", "隆司", "彩花", "俊介", "優奈", "裕斗", "咲良", "健吾", "由佳", "秀和", "菜穂子", "幸平", "心", "祥太", "楓", "大河", "香菜", "慶太", "未来絵", "彰", "楓香", "慶太郎", "彩", "敬太" };
			string[] LAST_NAMES =
				new string[] { "佐藤", "鈴木", "高橋", "田中", "渡辺", "伊藤", "山本", "中村", "小林", "加藤", "吉田", "山田", "佐々木", "山口", "松本", "井上", "木村", "林", "清水", "山崎", "阿部", "森", "池田", "橋本", "山下", "石川", "中島", "前田", "藤田", "小川", "後藤", "岡田", "長谷川", "村上", "近藤", "石井", "斎藤", "坂本", "遠藤", "青木", "藤原", "西村", "福田", "太田", "三浦", "藤井", "岡本", "松田", "中川", "中嶋", "原田", "小野", "田村", "竹内", "金子", "和田", "中山", "熊谷", "野口", "新井", "菅原", "大塚", "平野", "河野", "堀", "杉山", "服部", "岩崎", "安藤", "内田", "黒田", "川口", "高田", "関口", "古川", "島田", "市川", "白石", "小島", "秋山", "大橋", "荒木", "大久保", "田口", "宮崎", "北村", "木下", "村田", "吉川", "広瀬", "永井", "香川", "浜田", "石田", "前川", "坂口", "福崎", "松井", "森山", "菊地", "浅野", "古田", "小泉", "水野", "野村", "中田", "大西", "平岡", "金井", "青山", "嶋田", "菊池", "永田", "荒井", "小嶋", "戸田", "藤川", "井口", "白井", "関根", "鶴田", "福井", "酒井", "高野", "石崎", "大島", "沢田", "上野", "小柳" };
			string[] EMAIL_ACCOUNTS =
				new string[] { "johndoe", "janedoe", "mikesmith", "sarahlee", "davidbrown", "lisawang", "chrisjones", "amandabaker", "stevenkim", "laurabrown" };
			string[] EMAIL_DOMAINS =
				new string[] { "gmail.com", "yahoo.co.jp", "hotmail.com", "outlook.com", "aol.com", "icloud.com", "protonmail.com", "gmx.com", "zoho.com", "mail.com" };

			this.Customers = new List<CustomerInfo>(RECORD_COUNT);

			for (int count = 0; count < RECORD_COUNT; count++)
			{
				CustomerInfo customer = new CustomerInfo()
				{
					CustomerId = count + 1000000,
					FirstName = SCommon.CRandom.ChooseOne(FIRST_NAMES),
					LastName = SCommon.CRandom.ChooseOne(LAST_NAMES),
					Email = SCommon.CRandom.ChooseOne(EMAIL_ACCOUNTS) + "@" + SCommon.CRandom.ChooseOne(EMAIL_DOMAINS),
					PhoneNumber = SCommon.CRandom.GetRange(100, 999) + "-" + SCommon.CRandom.GetRange(1000, 9999) + "-" + SCommon.CRandom.GetRange(1000, 9999),
					Address = MakeAddress(),
					PostalCode = SCommon.CRandom.GetRange(100, 999) + "-" + SCommon.CRandom.GetRange(1000, 9999),
				};

				this.Customers.Add(customer);
			}
		}

		private string MakeAddress()
		{
			string[] PREFECTURES =
				new string[] { "北海道", "青森県", "岩手県", "宮城県", "秋田県", "山形県", "福島県", "茨城県", "栃木県", "群馬県", "埼玉県", "千葉県", "東京都", "神奈川県", "新潟県", "富山県", "石川県", "福井県", "山梨県", "長野県", "岐阜県", "静岡県", "愛知県", "三重県", "滋賀県", "京都府", "大阪府", "兵庫県", "奈良県", "和歌山県", "鳥取県", "島根県", "岡山県", "広島県", "山口県", "徳島県", "香川県", "愛媛県", "高知県", "福岡県", "佐賀県", "長崎県", "熊本県", "大分県", "宮崎県", "鹿児島県", "沖縄県" };
			string[] CITY_TOWN_NAMES =
				new string[] { "あさぎり", "いぶすき", "うぐいす島", "えんぴつ", "おおまち", "かもめ", "きりしま", "くろいし", "こまつ", "さくら", "しょうじょう", "たいよう", "つばさ", "てるおか", "ながねん", "にしい", "はなづき", "ひよどり", "ふうじょう", "ほしの", "まつおか", "めじろ台", "もみじが丘", "やまどり", "わかば", "旭丘", "金銀", "銀河", "紅葉谷", "桜ヶ丘", "紫苑", "紫陽花", "朱雀", "松風", "神代", "翠", "青海", "静岡山", "朝霧", "天空", "天竺", "桃源郷", "鳳凰", "夕焼け", "麒麟" };
			string[] HI_APARTMENT_NAMES =
				new string[] { "クリスタルタワー", "ロイヤルパレス", "グランドビュー", "シービューレジデンス", "メタロポリス", "シルバーコート", "ゴールデンハーバー", "パークサイドレジデンス", "フォレストヒルズ", "ハイランドパーク", "ブルームーブ", "ロックウェイレジデンス", "ダイアモンドハイツ", "プラチナヒルズ", "エンシェントキャッスル", "シティービューレジデンス", "サンセットプラザ", "マウンテンビューアパートメント", "ハーモニーガーデン", "プレミアムタワー" };
			string[] LW_APARTMENT_NAMES =
				new string[] { "サンライフ", "グリーンハイツ", "メゾン・ド・フルール", "サンハイツ", "パレス・コート", "シャトレー宝町", "ファミリア新宿", "サニーコート", "ローズガーデン", "マンションハイツ", "メリーゴーランド", "クラシックコート", "リバーサイドハウス", "オリエンタルハイツ", "パークハウス", "ハーモニーレジデンス", "サンセットハイツ", "オリンピアハイツ", "ニュータワー", "シャーメゾン" };

			string middle;
			string trail;
			string apartment;

			switch (SCommon.CRandom.GetInt(2))
			{
				case 0: middle =
					SCommon.CRandom.ChooseOne(CITY_TOWN_NAMES) + "市" +
					SCommon.CRandom.ChooseOne(CITY_TOWN_NAMES) + "区" +
					SCommon.CRandom.ChooseOne(CITY_TOWN_NAMES) + SCommon.CRandom.ChooseOne(new string[] { "町", "村" });
					break;

				case 1: middle =
					SCommon.CRandom.ChooseOne(CITY_TOWN_NAMES) + SCommon.CRandom.ChooseOne(new string[] { "市", "区" }) +
					SCommon.CRandom.ChooseOne(CITY_TOWN_NAMES) + SCommon.CRandom.ChooseOne(new string[] { "町", "村" });
					break;

				default:
					throw null;
			}

			switch (SCommon.CRandom.GetInt(2))
			{
				case 0: trail =
					SCommon.CRandom.GetRange(1, 9) + "丁目" +
					SCommon.CRandom.GetRange(1, 29) + "番地" +
					SCommon.CRandom.GetRange(1, 49) + "号";
					break;

				case 1: trail =
					SCommon.CRandom.GetRange(1000, 9999) + "番";
					break;

				default:
					throw null;
			}

			switch (SCommon.CRandom.GetInt(3))
			{
				case 0: apartment =
					"";
					break;

				case 1: apartment = " " +
					SCommon.CRandom.ChooseOne(HI_APARTMENT_NAMES) + " " +
					SCommon.CRandom.GetRange(1000, 9999) + "号室";
					break;

				case 2: apartment = " " +
					SCommon.CRandom.ChooseOne(HI_APARTMENT_NAMES) + " " +
					SCommon.CRandom.GetRange(1, 3) + "0" +
					SCommon.CRandom.GetRange(1, 9) + "号室";
					break;

				default:
					throw null;
			}

			string address =
				SCommon.CRandom.ChooseOne(PREFECTURES) +
				middle +
				trail +
				apartment;

			address = Common.HalfToFull(address);

			return address;
		}

		private const string SAVE_DATA_FILE = @"C:\temp\Customers.csv";

		public void Test01()
		{
			CreateCustomers();

			using (CsvFileWriter writer = new CsvFileWriter(SAVE_DATA_FILE))
			{
				foreach (CustomerInfo customer in this.Customers)
				{
					writer.WriteCell(customer.CustomerId.ToString());
					writer.WriteCell(customer.FirstName);
					writer.WriteCell(customer.LastName);
					writer.WriteCell(customer.Email);
					writer.WriteCell(customer.PhoneNumber);
					writer.WriteCell(customer.Address);
					writer.WriteCell(customer.PostalCode);
					writer.EndRow();
				}
			}

			this.Customers.Clear();

			using (CsvFileReader reader = new CsvFileReader(SAVE_DATA_FILE))
			{
				string[] row = reader.ReadRow();
				int c = 0;

				CustomerInfo customer = new CustomerInfo();

				customer.CustomerId = int.Parse(row[c++]);
				customer.FirstName = row[c++];
				customer.LastName = row[c++];
				customer.Email = row[c++];
				customer.PhoneNumber = row[c++];
				customer.Address = row[c++];
				customer.PostalCode = row[c++];

				this.Customers.Add(customer);
			}
		}
	}
}
