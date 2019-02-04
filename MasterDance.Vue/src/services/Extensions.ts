import authClient from './AuthenticationProxy'

export class BaseProxy {
    protected transformOptions(options) {
        options.headers['Authorization'] = `Bearer ${authClient.accessToken}`;
        return Promise.resolve(options);
    }
}