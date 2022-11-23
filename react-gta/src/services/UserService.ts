import { User, UserManager } from "oidc-client"

const config = {
    authority: "https://localhost:5001", 
    client_id: "client_id_react", 
    redirect_uri: "http://localhost:3000/callback",
    post_logout_redirect_uri: "http://localhost:3000/logout",
    silent_redirect_uri: `http://localhost:3000/refresh`,
    response_type: "code",
    scope: "openid profile AirlineTicketsAPI", 
    loadUserInfo: true,
}

const userManager = new UserManager(config)

export default class UserService {
  static async getUser() : Promise<User | null> {
    var user =  await userManager.getUser()
    return user
  }

  static async signIn(): Promise<void> {
    return await userManager.signinRedirect()
  }

  static async signInCallback(): Promise<User> {
    return await userManager.signinRedirectCallback()
  }

  static async signOut(): Promise<void> {
    var userTokenId = (await userManager.getUser())?.id_token

    userManager.clearStaleState()
    userManager.removeUser()
    await userManager.signoutRedirect({id_token_hint: userTokenId});
  }

  static async signOutCallback(): Promise<void> {
    await userManager.signoutRedirectCallback()
  }

  static async signInSilentCallback(): Promise<void> {
    await userManager.signinSilentCallback();
  }

  static async signInSilent(): Promise<void> {
    await userManager.signinSilentCallback();
  }
}