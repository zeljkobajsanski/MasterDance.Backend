import 'jstorage/jstorage.min'

declare const $: any;

class AuthenticationProxy {
    accessToken: string;
    refreshToken: string;

    constructor() {
        this.accessToken = $.jStorage.get('accessToken');
        this.refreshToken = $.jStorage.get('refreshToken');
        $.jStorage.listenKeyChange('accessToken', (key, action) => this.refreshAccessToken(action));
        $.jStorage.listenKeyChange('refreshToken', (key, action) => {
            if (action === 'delete') {
                this.logout();
            }
        });
    }

    isAuthenticated() {
        return this.accessToken != undefined || this.accessToken != null;
    }

    login(username: string, password: string) {
        let url_ = `/connect/token`;
        url_ = url_.replace(/[?&]$/, "");
        let data = new URLSearchParams();

        data.append('client_id', 'webapp');
        if (username != 'refresh_token') {
            data.append('grant_type', 'password');
            data.append('username', username);
            data.append('password', password);
        } else {
            data.append('grant_type', 'refresh_token');
            data.append('refresh_token', password);
        }

        let options_ = <RequestInit>{
            method: "POST",
            body: data,
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/x-www-form-urlencoded"
            }
        };

        return fetch(url_, options_).then(async (response) => {
            if (response.status === 200) {
                let token = await response.json();
                console.log('Login succeeded');
                this.accessToken = token['access_token'];
                this.refreshToken = token['refresh_token'];
                $.jStorage.set('accessToken', this.accessToken, {TTL: token['expires_in'] * 1000});
                $.jStorage.set('refreshToken', this.refreshToken);

            } else {
                this.logout();
                throw new Error('Neuspela prijava');
            }
        });
    }

    logout() {
        this.accessToken = null;
        this.refreshToken = null;
        $.jStorage.deleteKey('accessToken');
        $.jStorage.deleteKey('refreshToken');
    }

    private refreshAccessToken(action) {
        if (action === 'deleted' && this.refreshToken) {
            this.login('refresh_token', this.refreshToken);
        }
    }
}
const singleton = new AuthenticationProxy();
export default singleton;