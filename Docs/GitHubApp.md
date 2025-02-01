# Installation and Configuration of GitHub App

## Creating a GitHub App

### Open the Creation Page
1. Click on the icon in the top-right corner.
2. Select **Settings**.
3. Click **Developer settings**.

<img src="github_app1.jpg" width="600"/>

### Create the App

Click **New GitHub App**.

<img src="github_app2.jpg" width="600"/>

Set up your GitHub App:

- Provide a unique name for the **GitHub App name**.
- Enter `http://localhost` in the **Homepage URL** field.
- Uncheck the **Active** option for the webhook.

Set permissions as follows:

| Permissions  |  Read and write |
|---|---|
| Administration  |  Read and write |
| Contents  | Read and write  |
| Metadata  | Read-only  |
| Pull requests  |  Read-only  |

<img src="github_app3.jpg" width="600"/>

#### Save the App ID

Record the **App ID** and configure it as `BOT_APP_ID` in the repository secrets.

<img src="github_app4.jpg" width="600"/>

#### Generate a Private Key

Use **Generate a private key** to create one. The key file will be downloaded to your PC.  
This key must be configured as `BOT_PRIVATE_KEY` in the repository secrets.

<img src="github_app5.jpg" width="600"/>

### Install the App

Install the app created under your account.

<img src="github_app6.jpg" width="600"/>

Select **All repositories** and then complete the installation.

<img src="github_app7.jpg" width="600"/>

### Configure in the Repository

#### Setup Rules

Open the branch protection rules of the repository you want to configure and add the app to the **Bypass list**.

Navigate to:  
`Repository > Settings > Rules > Rulesets`

<img src="github_app8.jpg" width="600"/>

### Configure Secrets

Set the retrieved data as follows:

#### BOT_APP_ID

Enter the App ID.  
**Example:** `1130092`

#### BOT_PRIVATE_KEY

Copy and paste the private key downloaded to your PC.  
**Example:**
```
-----BEGIN RSA PRIVATE KEY-----
-----END RSA PRIVATE KEY-----
```

Navigate to:  
`Repository > Settings > Secrets and variables > Actions`

<img src="github_app9.jpg" width="600"/>