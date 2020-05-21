# FileNameScanner
比較一個目錄底下，某兩個副檔名是否有可以配對的檔案(同檔名)，並刪除沒有配對的檔案(可選)

## 前言
因為工作需求，需要用自己的data去訓練YOLO，但是往往實習生Labelimg切完檔案，圖片跟Xml常常對不上，一個目錄下隨便就幾千個檔案，人工處理實在是會瘋掉，所以這個專案就誕生了

## 專案環境
dotnet core 3.1 Console

## 使用方法

你可以Clone下在自己Build，或是直接載輸出檔 [x86](https://github.com/flyxiang1206/FileNameScanner/raw/master/ReleaseFile/FileNameScanner_x86.exe) [x64](https://github.com/flyxiang1206/FileNameScanner/raw/master/ReleaseFile/FileNameScanner_x64.exe)

#### 使用指令
```
FileNameScanner.exe -name FileExtension1 FileExtension2 -path Path
```
或是
```
FileNameScanner.exe -path Path -name FileExtension1 FileExtension2
```
> 範例
> ```
> FileNameScanner.exe -path D:\demo -name jpg xml
> ```

#### 使用結果範例
![](https://i.imgur.com/jt1yzdb.png)

如果有沒有對應到的檔案，他會問你是否要自動刪除<br/>

![](https://i.imgur.com/D60SlYK.png)

如果檔案都有對應到就會如上圖所示 ( 數量是兩個副檔名的數量 )

## 注意事項
本程式會自動掃描指定目錄下的所有目錄，不過比對的檔案只會在同一目錄下比對。
> D:\\File\Name.jpg  跟 D:\\File\Folder\Name.xml 是不會對應到的



