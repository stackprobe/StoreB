/*
	設定
*/

function* <generatorForTask> SettingMain()
{
	var<int> selectIndex = 0;

	FreezeInput();

gameLoop:
	for (; ; )
	{
		SetColor("#a0b0c0");
		PrintRect(0, 0, Screen_W, Screen_H);

		SetColor("#000000");
		SetPrint(70, 170, 50);
		SetFSize(40);
		PrintLine("設定");

		selectIndex = DrawSimpleMenu(
			selectIndex,
			70,
			200,
			600,
			30,
			[
				"音楽の音量",
				"効果音の音量",
				"ゲームパッド：Ｚキーの割り当て変更",
				"ゲームパッド：Ｘキーの割り当て変更",
				"ゲームパッド：スペースキーの割り当て変更",
				"データの消去",
				"戻る",
			]);

		if (DSM_Desided)
		switch (selectIndex)
		{
		case 0:
			yield* @@_VolumeSetting("音楽", MusicVolume, DEFAULT_MUSIC_VOLUME, function <void> (<double> volume)
			{
				MusicVolume = volume;
				MusicVolumeChanged();
				SaveLocalStorage();
			});
			break;

		case 1:
			yield* @@_VolumeSetting("効果音", SEVolume, DEFAULT_SE_VOLUME, function <void> (<double> volume)
			{
				SEVolume = volume;
				SaveLocalStorage();
			});
			break;

		case 2:
			yield* @@_PadSetting("Ｚ", index => PadInputIndex_A = index);
			break;

		case 3:
			yield* @@_PadSetting("Ｘ", index => PadInputIndex_B = index);
			break;

		case 4:
			yield* @@_PadSetting("スペース", index => PadInputIndex_Pause = index);
			break;

		case 5:
			yield* @@_RemoveSaveData();
			break;

		case 6:
			break gameLoop;
		}
		yield 1;
	}
	FreezeInput();
}

function* <generatorForTask> @@_VolumeSetting(<string> name, <double> initVolume, <double> defaultVolume, <Action double> volumeChanged)
{
	FreezeInput();

	var<int> volume = ToInt(initVolume * 100.0);

	for (var<int> frame = 0; ; frame++)
	{
		if (frame % 60 == 0)
		{
			SE(ChooseOne(S_テスト用));
		}

		if (GetMouseDown() == -1 || GetKeyInput(32) == 1)
		{
			break;
		}

		var<boolean> changed = false;

		if (IsPound(GetInput_2()))
		{
			volume -= 10;
			changed = true;
		}
		if (IsPound(GetInput_4()))
		{
			volume--;
			changed = true;
		}
		if (IsPound(GetInput_6()))
		{
			volume++;
			changed = true;
		}
		if (IsPound(GetInput_8()))
		{
			volume += 10;
			changed = true;
		}
		if (GetInput_B() == 1)
		{
			volume = defaultVolume * 100.0;
			changed = true;
		}
		if (GetInput_A() == 1)
		{
			break;
		}

		if (changed)
		{
			volume = ToRange(volume, 0, 100);
			volumeChanged(volume / 100.0);
		}

		SetColor("#a0b0c0");
		PrintRect(0, 0, Screen_W, Screen_H);

		SetColor("#000000");
		SetPrint(100, 280, 50);
		SetFSize(20);
		PrintLine(name + "の音量設定 ( 現在の音量 = " + volume + " )");
		PrintLine("上・右キー　⇒　音量を上げる");
		PrintLine("下・左キー　⇒　音量を上げる");
		PrintLine("Ｘキー　　　⇒　初期値に戻す");
		PrintLine("Ｚキー　　　⇒　戻る");
		PrintLine("メニューに戻るにはスペースキーまたは画面をクリックして下さい。");

		yield 1;
	}
	FreezeInput();
}

function* <generatorForTask> @@_PadSetting(<string> name, <Action int> a_setBtn)
{
	yield* WaitToReleaseButton();
	FreezeInput();

	for (; ; )
	{
		if (GetMouseDown() == -1 || GetKeyInput(32) == 1)
		{
			break;
		}

		var<int> index = @@_GetPressButtonIndex();

		if (index != -1)
		{
			a_setBtn(index);
			SaveLocalStorage();
			break;
		}

		SetColor("#a0b0c0");
		PrintRect(0, 0, Screen_W, Screen_H);

		SetColor("#000000");
		SetPrint(100, 360, 50);
		SetFSize(20);
		PrintLine("ゲームパッドの「" + name + "キー」設定");
		PrintLine("「" + name + "キー」を割り当てるボタンを押して下さい。");
		PrintLine("キャンセルするにはスペースキーまたは画面をクリックして下さい。");

		yield 1;
	}
	yield* WaitToReleaseButton();
	FreezeInput_Frame(2); // 決定ボタンが変更されるとメニューに戻った時、押下を検出してしまう。-- frame 1 -> 2
}

function <int> @@_GetPressButtonIndex()
{
	for (var<int> index = 0; index < 100; index++)
	{
		if (1 <= GetPadInput(index))
		{
			return index;
		}
	}
	return -1;
}

function* <generatorForTask> @@_RemoveSaveData()
{
	var<int> selectIndex = 0;

	FreezeInput();

gameLoop:
	for (; ; )
	{
		SetColor("#a0b0c0");
		PrintRect(0, 0, Screen_W, Screen_H);

		SetColor("#000000");
		SetPrint(100, 320, 50);
		SetFSize(20);
		PrintLine("セーブデータを完全に消去します。宜しいですか？");

		selectIndex = DrawSimpleMenu(
			selectIndex,
			70,
			350,
			600,
			30,
			[
				"はい",
				"いいえ",
			]);

		if (DSM_Desided)
		switch (selectIndex)
		{
		case 0:
			ClearLocalStorageValue();
			LoadLocalStorage();
			SE(S_SaveDataRemoved);
			break gameLoop;

		case 1:
			break gameLoop;
		}
		yield 1;
	}
	FreezeInput();
}
