import '@/assets/js/messenger/build/js/messenger';
import '@/assets/js/messenger/build/js/messenger-theme-flat';

declare const Messenger: any;

Messenger.options = {
    theme: 'air',
    extraClasses: 'messenger-fixed messenger-on-bottom messenger-on-right',
    hideAfter: 2,
    hideOnNavigate: true
};

class Notifications {
    info(message: string) {
        Messenger().info(message);
    }

    error(message: string) {
        Messenger().error(message);
    }
}

const instance = new Notifications();

export default instance;