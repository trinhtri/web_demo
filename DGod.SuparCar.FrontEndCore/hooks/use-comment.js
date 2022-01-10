import {useAppContext} from './use-app-context';

export const useComment = (key) => {
    const {data, setData} = useAppContext(`comment-${key}`);
    return {
        data: {
            ...(data || {})
        },
        updateCommentData: (payload) => {
            setData({
                ...payload
            });
        }
    };
};

