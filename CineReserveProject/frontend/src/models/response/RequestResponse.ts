export type RequestResponse<T> = SuccessResponse<T> | ErrorResponse

export type EmptyResponse = RequestResponse<null>

interface SuccessResponse<T> {
  value: T
  isSuccess: true
}

interface ErrorResponse {
  isSuccess: false
  error : Error
}

export type Error = {
  code: string
  description: string
  errorType: string
}
