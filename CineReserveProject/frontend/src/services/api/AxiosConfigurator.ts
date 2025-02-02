import type { EmptyResponse } from "@/models/response/RequestResponse";
import axios, { type AxiosRequestConfig, type AxiosResponse } from "axios";
import { useToast } from "vue-toast-notification";

/**
 * Defines global axios configuration.
 */
export class AxiosConfigurator {
  static readonly config: AxiosRequestConfig = {
    withCredentials: true,
    headers: {
      "Content-Type": "application/json",
      "Accept": "*/*; charset=utf-8"
    }
  }

  static readonly formDataConfig: AxiosRequestConfig = {
    ...AxiosConfigurator.config,
    headers: {
      ...AxiosConfigurator.config.headers,
      "Content-Type": "multipart/form-data"
    }
  }

  static getInstance(serverUrl: string, endpoint: string, isFormData = false) {
    const config = isFormData ? AxiosConfigurator.formDataConfig : AxiosConfigurator.config
    const abortController = new AbortController()

    const axiosInstance = axios.create({
      ...config,
      baseURL: `${serverUrl}/${endpoint}`,
      signal: abortController.signal,
      responseType: "json"
    })

    axiosInstance.interceptors.response.use(
      (response: AxiosResponse) => response,
      (({ response }: { response: AxiosResponse<EmptyResponse> }) => {
        const toast = useToast()
        if (response?.data?.isSuccess === false && response.data?.error) {
          const { code, description, errorType} = response.data.error
          toast.error(`Error Code: ${code} - ${description} (${errorType})`)
          return Promise.reject(response.data.error)
        } else {
          toast.error('An unexpected error occurred. Please contact the support.')
          return Promise.reject(response)
        }
      })
    )
    return axiosInstance
  }
}
