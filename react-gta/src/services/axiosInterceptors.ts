import axiosInstance from '../instances/axiosInstance';
import UserService from './UserService';

const addAxiosInterceptors = () => {
  axiosInstance.interceptors.request.use(
    async (config: any) => {
      const token = await UserService.getUser().then((user) => {
        return user?.access_token;
      });
      if (token) config.headers.Authorization = `Bearer ${token}`;
      return config;
    },
    (error) => {
      return Promise.reject(error);
    }
  );
};

export default addAxiosInterceptors;
