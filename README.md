# TestingVault

Для начала щапускаем команду для поддержки vault
docker pull vault

Создаем контейнер с Vault
docker run --name vault -p 8200:8200 vault:latest
Результатом команды в консоли будет выведен следующая команда

You may need to set the following environment variable:

    $ export VAULT_ADDR='http://0.0.0.0:8200'

The unseal key and root token are displayed below in case you want to
seal/unseal the Vault or re-authenticate.

Unseal Key: TkSC74J0vzClvql9IEUJwdHvtyL+gLybyWWk0DWQ7zU=
Root Token: hvs.pbqnPGi3Y5I44FK4rlGAZxCF

Development mode should NOT be used in production installations!

Скопируйте токен из RootToken и перенести в appsittegs.json полю vault token
Так же запустите команду export VAULT_ADDR='http://0.0.0.0:8200' но в терминале контейнера который мы создали ранее
Так же введите коменлу export VAULT_TOKEN='токен из RootToken' для того чо бы не логиниться в теминаое докер контейнер

Далее в терминал докер крейсера введите команду для создания секретного ключа

Vault kv put secret/tdc tdcpassword=test1234


