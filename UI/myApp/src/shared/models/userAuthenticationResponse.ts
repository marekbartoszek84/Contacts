export interface UserAuthenticationResponse {
  isAuthSuccessful: boolean;
  errorMessage: string;
  token: string;
}
