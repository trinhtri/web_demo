
import { useAppContext } from './use-app-context';

export const useAuth = () => {
  return useAppContext('auth');
};

