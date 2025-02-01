# GitHub Appのインストールと設定

## GitHub Appの生成

### 生成ページを開く
1. 右上のアイコンをクリック
2. Settingsをクリック
3. Developer settingsをクリック

<img src="github_app1.jpg" width="600"/>

### 生成

New GiHub Appをクリック

<img src="github_app2.jpg" width="600"/>

GitHub Appを作成します。

- GitHub App nameに適当に入力、ユニークである必要があります。
- Homepage URLに`http://localhost`と入力
- WebfookのActiveを選択解除する

Permissionsを下記のように指定

| Permissions  |  Read and write |
|---|---|
| Administration  |  Read and write |
| Contents  | Read and write  |
| Metadata  | Read-only  |
| Pull requests  |  Read-only |

<img src="github_app3.jpg" width="600"/>

#### App IDを控える

App IDは、Repository secretsのBOT_APP_IDに設定します。

<img src="github_app4.jpg" width="600"/>

#### Private keyの生成

`Generate a private key`から設定。ファイルがPCにダウンロードされます。
このキーは、Repository secretsのBOT_PRIVATE_KEYに設定します。

<img src="github_app5.jpg" width="600"/>


### Appのインストール

アカウントに生成したAppをインストールします。

<img src="github_app6.jpg" width="600"/>


All repositoriesを選択してインストール。

<img src="github_app7.jpg" width="600"/>

### リポジトリに設定

#### ルールの設定

設定したいリポジトリのブランチ保護ルールを開き、Bypass listにAppを設定してください。

`リポジトリ > Settings > Rules > Rulesets`  
<img src="github_app8.jpg" width="600"/>

### シークレットの設定

上記で取得したデータを設定します。

#### BOT_APP_ID

アプリのIDを設定  
**例)** 1130092

#### BOT_PRIVATE_KEY

PCにダウンロードしたアプリのシークレットの中身をコピペ  
**例)**
```
-----BEGIN RSA PRIVATE KEY-----
省略
-----END RSA PRIVATE KEY-----
```

`リポジトリ > Settings > Secrets and variables > Actions`  
<img src="github_app9.jpg" width="600"/>