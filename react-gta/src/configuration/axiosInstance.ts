import axios from 'axios';
import { axiosConfig } from './axiosConfig';

const axiosInstance = axios.create({
  baseURL: axiosConfig.baseUrl,
});

export default axiosInstance;
