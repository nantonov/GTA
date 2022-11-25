import { Provider } from "react-redux";
import { AuthProvider } from "./components/authorization/AuthProvider";
import AppRouter from "./components/routing/AppRouter";
import store from "./store/store";

function App() {
  return (
    <div className="App">
      <Provider store={store}>
        <AuthProvider>
          <AppRouter />
        </AuthProvider>
      </Provider>
    </div>
  );
}

export default App;
