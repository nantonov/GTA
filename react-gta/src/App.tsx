import React from 'react';
import { Provider } from 'react-redux';
import AppRouter from './components/routing/AppRouter';
import store from './store/store';

const App = () => {
  return (
    <div className="App">
      <Provider store={store}>
        <AppRouter />
      </Provider>
    </div>
  );
};

export default App;
