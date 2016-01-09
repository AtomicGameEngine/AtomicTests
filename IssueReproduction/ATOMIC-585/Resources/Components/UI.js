"atomic component";

var WIDTH = 900;
var HEIGHT = 640;

var view = new Atomic.UIView();

//UI component
exports.component = function(self) {

  // Create a UIWindow
  var window = new Atomic.UIWindow();
  window.text = "UITabContainer";
  window.setSize(WIDTH, HEIGHT);

  var tabContainer = new Atomic.UITabContainer();
  
  // ISSUE: https://github.com/AtomicGameEngine/AtomicGameEngine/issues/585
  // Adding child here does not set initial content sizes properly
  window.addChild(tabContainer); 
  
  tabContainer.gravity = Atomic.UI_GRAVITY_ALL;

  var content = tabContainer.contentRoot;
  var tabs = tabContainer.tabLayout;

  var button = new Atomic.UIButton();
  button.text = "Hello";
  tabs.addChild(button);

  var button2 = new Atomic.UIButton();
  button2.gravity = Atomic.UI_GRAVITY_ALL;
  button2.text = "Content";
  
  content.addChild(button2);

  tabContainer.currentPage = 0;

  // Add to main UI view and center
  
  // ISSUE: https://github.com/AtomicGameEngine/AtomicGameEngine/issues/585
  // Adding child here, which some content children, does do initial sizing properly
  // window.addChild(tabContainer);
  
  view.addChild(window);
  window.center();

}


