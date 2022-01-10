import {useAppContext} from './use-app-context';

export const useModal = (key) => {
    const {data, setData} = useAppContext(key);
    return {
        ...(data || {}),

        open: (payload) => {
            setData({
                isOpened: true,
                data: payload,
            });
        },

        close: () => {
            setData({
                ...data,
                isOpened: false,
            });
        },
    };
};

