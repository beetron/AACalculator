using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AACookBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();

        }

        private new void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        // Reset Button Click
        private void ButtonReset_OnClick(object sender, RoutedEventArgs e)
        {

            // MessageBox.Show(this.CookBox.Text);
            this.CookCount.Text = this.AlchCount.Text = this.laborBox.Text = "0";
            //this.CookBox.SelectedIndex = this.AlchBox.SelectedIndex = 0;
            this.matCount.Text = this.alchMatname.Text = this.alchMatcount.Text = null;
            this.matName.Text = "※が付いているレシピは錬金工房が前提。";
        }

        // Calculate Button Click
        private void ButtonCalculate_OnClick(object sender, RoutedEventArgs e)
        {
            // If count is empty, sets the value to 0 to prevent exception error
            if(String.IsNullOrEmpty(this.CookCount.Text))
            {
                this.CookCount.Text = "0";
            }
            if(String.IsNullOrEmpty(this.AlchCount.Text))
            {
                this.AlchCount.Text="0";
            }

            var cC = Convert.ToInt32(CookCount.Text);
            var aC = Convert.ToInt32(AlchCount.Text);

            // Skill levels

            // Cooking Ingredients
            var hustleKokumotsu = 40;
            var hustleMugi = 10;
            var hustleMoringa = 1;
            var hustleNinniku = 8;
            var hustleSatsumaimo = 6;
            var hustleIchigo = 3;

            var genkiKokumotsu = 150;
            var genkiMugi = 20;
            var genkiNatsume = 3;
            var genkiTomato = 10;
            var genkiKabocha = 5;
            var genkiRose = 3;

            var karubiYasai = 100;
            var karubiNiku = 300;
            var karubiKoushin = 100;
            var karubiMoringa = 40;
            var karubiHachimitsu = 10;
            var karubiTochu = 20;

            var tappuriTamago = 25;
            var tappuriKomugi = 50;
            var tappuriButa = 25;
            var tappuriTamanegi = 25;
            var tappuriCorn = 25;
            var tappuriNinjin = 5;
            var tappuriKinoko = 20;

            var kaisenNinjin = 10;
            var kaisenTamanegi = 10;
            var kaisenEnbaku = 10;
            var kaisenKome = 20;
            var kaisenKinoko = 10;
            var kaisenMentai = 2;
            var kaisenCray = 8;
            var kaisenHitode = 5;

            var fruitOrange = 5;
            var fruitBanana = 5;
            var fruitRingo = 5;
            var fruitIchigo = 5;
            var fruitCherry = 5;
            var fruitBudo = 5;
            var fruitHachimitsu = 7;

            var syabuButa = 10;
            var syabuGyu = 10;
            var syabuTori = 10;
            var syabuKinoko = 10;
            var syabuNinjin = 10;
            var syabuHitsuji = 10;
            var syabuCray = 5;
            var syabuHitode = 2;

            var karaTori = 20;
            var karaKomugi = 15;
            var karaKosho = 10;
            var karaNinniku = 10;
            var karaJyagaimo = 20;
            var karaTamago = 20;
            var karaKome = 20;

            var sasaJyagaimo = 50;
            var sasaSuzuki = 1;
            var sasaTara = 1;
            var sasaFugu = 5;
            var sasaMentai = 1;

            var jingisuHitsuji = 10;
            var jingisuNinjin = 8;
            var jingisuTamanegi = 8;
            var jingisuKosho = 8;
            var jingisuKabocha = 8;
            var jingisuTogarashi = 8;
            var jingisuCorn = 8;

            //Alchemy Ingredients
            var kanpekiYaku = 50;
            var kanpekiSyobu = 20;
            var kanpekiAzami = 20;
            var kanpekiGekkei = 5;
            var kanpekiYaguru = 5;
            var kanpekiAroe = 8;

            var usuguraiPotion = 10;
            var usuguraiSumire = 5;
            var usuguraiYaku = 10;

            var seijyakuYaku = 165;
            var seijyakuKeshi = 20;
            var seijyakuAroe = 35;
            var seijyakuYaguru = 35;
            var seijyakuAzami = 50;
            var seijyakuSyobu = 50;

            var yureruPotion = 10;
            var yureruSuika = 10;
            var yureruYaku = 60;

            var goldYaku = 40;
            var goldLavender = 20;
            var goldIcho = 3;
            var goldKinoko = 20;
            var goldSuisen = 20;
            var goldYuri = 8;

            var amaiPotion = 10;
            var amaiMukuge = 5;
            var amaiYaku = 8;

            var mugenYaku = 155;
            var mugenIcho = 10;
            var mugenKorai = 20;
            var mugenHasu = 20;
            var mugenKinoko = 40;
            var mugenLavender = 40;

            var afureruPotion = 10;
            var afureruHosenka = 10;
            var afureruYaku = 60;

            //Labor control variable
            var cookingLabor = 0;
            var alchemyLabor = 0;

            //this.matName.Text = Convert.ToString(cC);
            //this.matCount.Text = Convert.ToString(aC);

            //Cooking recipe            

            if (cC > 0)
            {
                if (CookBox.SelectedIndex == 0) //if (CookBox.Text == "ハッスルパン")
                {
                    var hustlepan = cookingLabor = 75;
                    matName.Text = "粉砕した穀物:\n 麦:\n モリンガの実:\n ニンニク:\n サツマイモ:\n イチゴ:";
                    matCount.Text = cC * hustleKokumotsu + "\n" + cC * hustleMugi + "\n" +
                                    cC * hustleMoringa + "\n" + cC * hustleNinniku + "\n" +
                                    cC * hustleSatsumaimo + "\n" + cC * hustleIchigo;
                }
                else if (CookBox.SelectedIndex == 1) //元気回復のスープ
                {
                    var genkisoup = cookingLabor = 75;
                    matName.Text = "粉砕した穀物:\n 麦:\n ナツメヤシ:\n トマト:\n カボチャ:\n ローズマリー:";
                    matCount.Text = cC * genkiKokumotsu + "\n" + cC * genkiMugi + "\n" + cC * genkiNatsume +
                                    "\n" +
                                    cC * genkiTomato + "\n" + cC * genkiKabocha + "\n" +
                                    cC * genkiRose;
                }
                else if (CookBox.SelectedIndex == 2) //熟成カルビ盛り合わせ焼き
                {
                    var karubi = cookingLabor = 300;
                    matName.Text = "手入れした肉:\n 切れた野菜:\n 破砕した香辛料:\n モリンガの実:\n ハチミツ:\n 冬虫夏草:";
                    matCount.Text = cC * karubiNiku + "\n" + cC * karubiYasai + "\n" + cC * karubiKoushin +
                                    "\n" + cC * karubiMoringa + "\n" + cC * karubiHachimitsu + "\n" +
                                    cC * karubiTochu;
                }
                else if (CookBox.SelectedIndex == 3) //たっぷり野菜の豚バラ焼豚麺
                {
                    var tappuri = cookingLabor = 100;
                    matName.Text = "卵:\n 小麦:\n 豚肉:\n タマネギ:\n トウモロコシ:\n ニンジン:\n キノコ:";
                    matCount.Text = cC * tappuriTamago + "\n" + cC * tappuriKomugi + "\n" + cC * tappuriButa + "\n" +
                                    cC * tappuriTamanegi + "\n" + cC * tappuriCorn + "\n" + cC * tappuriNinjin + "\n" +
                                    cC * tappuriKinoko;
                }
                else if (CookBox.SelectedIndex == 4) //海鮮雑炊
                {
                    var zousui = cookingLabor = 100;
                    matName.Text = "ニンジン:\n タマネギ:\n エンバク:\n 米:\n キノコ:\n メンタイ:\n クレイフィッシュ:\n ヒトデ:";
                    matCount.Text = cC * kaisenNinjin + "\n" + cC * kaisenTamanegi + "\n" + cC * kaisenEnbaku + "\n" +
                                    cC * kaisenKome + "\n" + cC * kaisenKinoko + "\n" + cC * kaisenMentai + "\n" +
                                    cC * kaisenCray + "\n" + cC * kaisenHitode;
                }
                else if (CookBox.SelectedIndex == 5) //フルーツポンチ
                {
                    var fruitspunch = cookingLabor = 100;
                    matName.Text = "オレンジ:\n バナナ:\n リンゴ:\n イチゴ:\n チェリー:\n ブドウ:\n ハチミツ:";
                    matCount.Text = cC * fruitOrange + "\n" + cC * fruitBanana + "\n" + cC * fruitRingo + "\n" +
                                    cC * fruitIchigo + "\n" +
                                    cC * fruitCherry + "\n" + cC * fruitBudo + "\n" + cC * fruitHachimitsu;
                }
                else if (CookBox.SelectedIndex == 6) //しゃぶしゃぶ
                {
                    var syabusyabu = cookingLabor = 100;
                    matName.Text = "豚肉:\n 牛肉:\n 鶏肉:\n キノコ:\n ニンジン:\n 羊肉:\n クレイフィッシュ:\n ヒトデ:";
                    matCount.Text = cC * syabuButa + "\n" + cC * syabuGyu + "\n" + cC * syabuTori + "\n" +
                                    cC * syabuKinoko + "\n" + cC * syabuNinjin + "\n" + cC * syabuHitsuji + "\n" +
                                    cC * syabuCray + "\n" + cC * syabuHitode;
                }
                else if (CookBox.SelectedIndex == 7) //若鶏の唐揚げ
                {
                    var karaage = cookingLabor = 100;
                    matName.Text = "鶏肉:\n 小麦:\n コショウ:\n ニンニク:\n ジャガイモ:\n 卵:\n 米:";
                    matCount.Text = cC * karaTori + "\n" + cC * karaKomugi + "\n" + cC * karaKosho + "\n" +
                                    cC * karaNinniku + "\n" + cC * karaJyagaimo + "\n" + cC * karaTamago + "\n" +
                                    cC * karaKome;
                }
                else if (CookBox.SelectedIndex == 8) //笹かまぼこ
                {
                    var sasakama = cookingLabor = 100;
                    matName.Text = "ジャガイモ:\n スズキ:\n タラ:\n フグ:\n メンタイ:";
                    matCount.Text = cC * sasaJyagaimo + "\n" + cC * sasaSuzuki + "\n" + cC * sasaTara + "\n" +
                                    cC * sasaFugu + "\n" + cC * sasaMentai;
                }
                else if (CookBox.SelectedIndex == 9) //ジンギスカン
                {
                    var jingisukan = cookingLabor = 20;
                    matName.Text = "羊肉:\n ニンジン:\n タマネギ:\n コショウ:\n カボチャ:\n トウガラシ:\n トウモロコシ:";
                    matCount.Text = cC * jingisuHitsuji + "\n" + cC * jingisuNinjin + "\n" + cC * jingisuTamanegi +
                                    "\n" + cC * jingisuKosho + "\n" + cC * jingisuKabocha + "\n" +
                                    cC * jingisuTogarashi + "\n" + cC * jingisuCorn;
                }
            }

            // Alchemy recipe
            if (aC > 0)
            {
                if (AlchBox.SelectedIndex == 0)
                {
                    var kanpeki = alchemyLabor = 30;
                    alchMatname.Text = "いぶした薬剤:\n ショウブ:\n アザミ:\n 月桂樹の葉:\n ヤグルマギク:\n アロエ:";
                    alchMatcount.Text = aC * kanpekiYaku + "\n" + aC * kanpekiSyobu + "\n" + aC * kanpekiAzami + "\n" +
                                        aC * kanpekiGekkei + "\n" + aC * kanpekiYaguru + "\n" + aC * kanpekiAroe;
                }
                else if (AlchBox.SelectedIndex == 1)
                {
                    var usugurai = alchemyLabor = 20;
                    alchMatname.Text = "完璧な永遠の記憶・MPポーション(小):\n スミレ:\n いぶした薬剤:";
                    alchMatcount.Text = aC * usuguraiPotion + "\n" + aC * usuguraiSumire + "\n" + aC * usuguraiYaku;
                }
                else if (AlchBox.SelectedIndex == 2)
                {
                    var seijyaku = alchemyLabor = 160;
                    alchMatname.Text = "いぶした薬剤:\n ケシ:\n アロエ:\n ヤグルマギク:\n アザミ:\n ショウブ:";
                    alchMatcount.Text = aC * seijyakuYaku + "\n" + aC * seijyakuKeshi + "\n" + aC * seijyakuAroe +
                                        "\n" + aC * seijyakuYaguru + "\n" + aC * seijyakuAzami + "\n" +
                                        aC * seijyakuSyobu;
                }
                else if (AlchBox.SelectedIndex == 3)
                {
                    var yureru = alchemyLabor = 45;
                    alchMatname.Text = "静寂な暴風の目・MPポーション:\n スイカ:\n いぶした薬剤:";
                    alchMatcount.Text = aC * yureruPotion + "\n" + aC * yureruSuika + "\n" + aC * yureruYaku;
                }
                else if (AlchBox.SelectedIndex == 4)
                {
                    var goldpot = alchemyLabor = 25;
                    alchMatname.Text = "いぶした薬剤:\n ラベンダー:\n イチョウの葉:\n キノコ:\n スイセン:\n ユリ:";
                    alchMatcount.Text = aC * goldYaku + "\n" + aC * goldLavender + "\n" + aC * goldIcho + "\n" +
                                        aC * goldKinoko + "\n" + aC * goldSuisen + "\n" + aC * goldYuri;
                }
                else if (AlchBox.SelectedIndex == 5)
                {
                    var amai = alchemyLabor = 20;
                    alchMatname.Text = "ゴールド平原の蜃気楼・HPポーション(小):\n ムクゲ:\n いぶした薬剤:";
                    alchMatcount.Text = aC * amaiPotion + "\n" + aC * amaiMukuge + "\n" + aC * amaiYaku;
                }
                else if (AlchBox.SelectedIndex == 6)
                {
                    var mugenpot = alchemyLabor = 114;
                    alchMatname.Text = "いぶした薬剤:\n イチョウの葉:\n 高麗ニンジン:\n ハス:\n キノコ:\n ラベンダー:";
                    alchMatcount.Text = aC * mugenYaku + "\n" + aC * mugenIcho + "\n" + aC * mugenKorai + "\n" +
                                        aC * mugenHasu + "\n" + aC * mugenKinoko + "\n" + aC * mugenLavender;
                }
                else if (AlchBox.SelectedIndex == 7)
                {
                    var afurerupot = alchemyLabor = 30;
                    alchMatname.Text = "無限の命の車輪・HPポーション:\n ホウセンカ:\n いぶした薬剤:";
                    alchMatcount.Text = aC * afureruPotion + "\n" + aC * afureruHosenka + "\n" + aC * afureruYaku;
                }
            }

            // Labor Calculation IF statements
            if (cC != 0 || aC != 0)
            {
                if (skillBox.SelectedIndex == 0)
                {
                    laborBox.Text = Convert.ToInt32((cookingLabor * cC) + (alchemyLabor * aC)).ToString();
                }
                else if (skillBox.SelectedIndex == 1)
                {
                    laborBox.Text = Convert.ToInt32(((cookingLabor - (cookingLabor * 0.05)) * cC) + ((alchemyLabor - (alchemyLabor * 0.05)) * aC)).ToString();
                }
                else if (skillBox.SelectedIndex == 2)
                {
                    laborBox.Text = Convert.ToInt32(((cookingLabor - (cookingLabor * 0.1)) * cC) + ((alchemyLabor - (alchemyLabor * 0.1)) * aC)).ToString();
                }
                else if (skillBox.SelectedIndex == 3)
                {
                    laborBox.Text = Convert.ToInt32(((cookingLabor - (cookingLabor * 0.15)) * cC) + ((alchemyLabor - (alchemyLabor * 0.15)) * aC)).ToString();
                }
                else if (skillBox.SelectedIndex == 4)
                {
                    laborBox.Text = Convert.ToInt32(((cookingLabor - (cookingLabor * 0.2)) * cC) + ((alchemyLabor - (alchemyLabor * 0.2)) * aC)).ToString();
                }
                else if (skillBox.SelectedIndex == 5)
                {
                    laborBox.Text = Convert.ToInt32(((cookingLabor - (cookingLabor * 0.25)) * cC) + ((alchemyLabor - (alchemyLabor * 0.25)) * aC)).ToString();
                }
                else if (skillBox.SelectedIndex == 6)
                {
                    laborBox.Text = Convert.ToInt32(((cookingLabor - (cookingLabor * 0.3)) * cC) + ((alchemyLabor - (alchemyLabor * 0.3)) * aC)).ToString();
                }
                else if (skillBox.SelectedIndex == 7)
                {
                    laborBox.Text = Convert.ToInt32(((cookingLabor - (cookingLabor * 0.4)) * cC) + ((alchemyLabor - (alchemyLabor * 0.4)) * aC)).ToString();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CookBox_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> cookRecipe = new List<string>();
            cookRecipe.Insert(0, "※ハッスルパン(10)");
            cookRecipe.Insert(1, "※元気回復のスープ(10)");
            cookRecipe.Insert(2,"※熟成カルビ盛り合わせ焼き(10)");
            cookRecipe.Insert(3,"たっぷり野菜の豚バラ焼豚麺");
            cookRecipe.Insert(4,"海鮮雑炊");
            cookRecipe.Insert(5,"フルーツポンチ");
            cookRecipe.Insert(6,"しゃぶしゃぶ");
            cookRecipe.Insert(7,"若鶏の唐揚げ");
            cookRecipe.Insert(8,"笹かまぼこ");
            cookRecipe.Insert(9,"ジンギスカン");
            var cookCombo = sender as ComboBox;
            cookCombo.ItemsSource = cookRecipe;
            cookCombo.SelectedIndex = 0;

        }
        private void CookBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var cookSelectedcombo = sender as ComboBox;
            //string name = cookSelectedcombo.SelectedItem as string;
            //MessageBox.Show(name);
        }
        private void AlchBox_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> alchRecipe = new List<string>();
            alchRecipe.Insert(0, "※完璧な永遠の記憶・MPポーション(小)(10)");
            alchRecipe.Insert(1,"薄暗い思い出の欠片・MPポーション(小)(10)");
            alchRecipe.Insert(2, "※静寂な暴風の目・MPポーション(10)");
            alchRecipe.Insert(3,"揺れる波・MPポーション(10)");
            alchRecipe.Insert(4, "※ゴールド平原の蜃気楼・HPポーション(小)(10)");
            alchRecipe.Insert(5,"甘いスターライト・HPポーション(小)(10)");
            alchRecipe.Insert(6, "※無限の命の車輪・HPポーション(10)");
            alchRecipe.Insert(7,"溢れる愛の力・HPポーション(10)");
            var alchCombo = sender as ComboBox;
            alchCombo.ItemsSource = alchRecipe;
            alchCombo.SelectedIndex = 0;
        }

        // Skill level selector
        private void skillBoxLoaded(object sender, RoutedEventArgs e)
        {
            List<string> skillLevel = new List<string>();
            skillLevel.Insert(0, "1:見習い");
            skillLevel.Insert(1, "2:熟練");
            skillLevel.Insert(2, "3:専門");
            skillLevel.Insert(3, "4:匠");
            skillLevel.Insert(4, "5:職人1~4");
            skillLevel.Insert(5, "9:職人5");
            skillLevel.Insert(6, "10:名人");
            skillLevel.Insert(7, "☆:神業");
            var skillCombo = sender as ComboBox;
            skillCombo.ItemsSource = skillLevel;
            skillCombo.SelectedIndex = 0;
        }

        // Window always on top
        private void CheckBox_OnClick(object sender, RoutedEventArgs e)
        {
            if (checkBox.IsChecked == true)
            {
                this.Topmost = true;
            }
            else if (checkBox.IsChecked == false)
            {
                this.Topmost = false;
            }
        }
    }
}
