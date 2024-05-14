import { createContext, useEffect, useReducer } from "react";

const INITIAL_STATE={
    user:null,
    loading:false,
    error:null
};
export const AuthContext =createContext(INITIAL_STATE)

const AuthReducer = (state, action) => {
    switch (action.type) {
      case "LOGIN_START":
        return {
          ...state,
          loading: true,
          error: null,
        };
      case "LOGIN_SUCCESS":
        const { userId, token } = action.payload;
        return {
          user: userId,
          token: token,
          loading: false,
          error: null,
        };
      case "LOGIN_FAILURE":
        return {
          ...state,
          loading: false,
          error: action.payload,
        };
      case "LOGOUT":
        localStorage.removeItem('token'); 
        localStorage.removeItem('userId'); 
        return {
          ...state,
          user: null,
          token: null,
          loading: false,
          error: null,
        };
      default:
        return state;
    }
  };
export const AuthContextProvider=({children})=>{
    const [state,dispatch]=useReducer(AuthReducer,INITIAL_STATE);
    
    useEffect(()=>{
localStorage.setItem("user",JSON.stringify(state.user))

    },[state.user])
    
    return(
        <AuthContext.Provider
  value={{user:state.user,
    loading:state.loading,
    error:state.error,
   dispatch}}
          >
            {children}
            </AuthContext.Provider>
    )
}