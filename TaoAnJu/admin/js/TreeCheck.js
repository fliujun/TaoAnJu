function OnTreeNodeChecked(id, type) {
    //获取触发事件的对象 
    var element = window.event.srcElement;
    //如果对象不是checkbox则不处理 
    if (!IsCheckBox(element))
        return;
    //获取checked状态 
    var isChecked = element.checked;
    //获取tree对象 
    var tree = TV2_GetTreeById(id);
    //获取element的相对结点(如果是叶结点，则就为element,否则为其<A>结点) 
    var node = TV2_GetNode(tree, element);
    switch (type) {
        case "1":
            SetNodesUnChecked(tree);
            element.checked = true;
            break;
        case "2":
            TV2_SetChildNodesCheckStatus(node, isChecked);
            break;
        case "3":
            TV2_SetChildNodesCheckStatus(node, isChecked);
            var parent = TV2_GetParentNode(tree, node);
            TV2_NodeOnChildNodeCheckedChanged(tree, parent, isChecked);
    }
}
//set all nodes checkbox nochecked 
function SetNodesUnChecked(TreeNode) {
    var inputs = WebForm_GetElementsByTagName(TreeNode, "INPUT");
    if (inputs == null || inputs.length == 0)
        return;
    for (var i = 0; i < inputs.length; i++) {
        if (IsCheckBox(inputs[i]))
            inputs[i].checked = false;
    }
}
//set child nodes checkbox status 
function TV2_SetChildNodesCheckStatus(node, isChecked) {
    //返回当前node所在的div层 
    var childNodes = TV2i_GetChildNodesDiv(node);
    if (childNodes == null)
        return;
    var inputs = WebForm_GetElementsByTagName(childNodes, "INPUT");
    if (inputs == null || inputs.length == 0)
        return;
    for (var i = 0; i < inputs.length; i++) {
        if (IsCheckBox(inputs[i]))
            inputs[i].checked = isChecked;
    }
}
//change parent node checkbox status after child node changed 
function TV2_NodeOnChildNodeCheckedChanged(tree, node, isChecked) {
    if (node == null)
        return;
    var childNodes = TV2_GetChildNodes(tree, node);
    if (childNodes == null || childNodes.length == 0)
        return;
    var isAllSame = true;
    for (var i = 0; i < childNodes.length; i++) {
        var item = childNodes[i];
        var value = TV2_NodeGetChecked(item);
        if (isChecked != value) {
            isAllSame = false;
            break;
        }
    }
    var parent = TV2_GetParentNode(tree, node);
    if (isAllSame) {
        TV2_NodeSetChecked(node, isChecked);
        TV2_NodeOnChildNodeCheckedChanged(tree, parent, isChecked);
    }
    else {
        TV2_NodeSetChecked(node, true);
        TV2_NodeOnChildNodeCheckedChanged(tree, parent, true);
    }
}
//get node relative element(etc. checkbox) 
function TV2_GetNode(tree, element) {
    var id = element.id.replace(tree.id, "");
    id = id.toLowerCase().replace(element.type, "");
    id = tree.id + id;
    var node = document.getElementById(id);
    if (node == null) //leaf node, no "A" node 
        return element;
    return node;
}
//get parent node 
function TV2_GetParentNode(tree, node) {
    var div = WebForm_GetParentByTagName(node, "DIV");
    //The structure of node: <table>information of node</table><div>child nodes</div> 
    var table = div.previousSibling;
    if (table == null)
        return null;
    return TV2i_GetNodeInElement(tree, table);
}
//get child nodes array 
function TV2_GetChildNodes(tree, node) {
    if (TV2_NodeIsLeaf(node))
        return null;
    var children = new Array();
    var div = TV2i_GetChildNodesDiv(node);
    var index = 0;
    for (var i = 0; i < div.childNodes.length; i++) {
        var element = div.childNodes[i];
        if (element.tagName != "TABLE")
            continue;
        var child = TV2i_GetNodeInElement(tree, element);
        if (child != null)
            children[index++] = child;
    }
    return children;
}
function TV2_NodeIsLeaf(node) {
    return !(node.tagName == "A"); //Todo 
}
function TV2_NodeGetChecked(node) {
    var checkbox = TV2i_NodeGetCheckBox(node);
    return checkbox.checked;
}
function TV2_NodeSetChecked(node, isChecked) {
    var checkbox = TV2i_NodeGetCheckBox(node);
    if (checkbox != null)
        checkbox.checked = isChecked;
}
function IsCheckBox(element) {
    if (element == null)
        return false;
    return (element.tagName == "INPUT" && element.type.toLowerCase() == "checkbox");
}
//get tree 
function TV2_GetTreeById(id) {
    return document.getElementById(id);
}
////////////////////////////////////////////////////////////////////////////////////////////// 
//private mothods, with TV2i_ prefix 
////////////////////////////////////////////////////////////////////////////////////////////// 
//get div contains child nodes 
function TV2i_GetChildNodesDiv(node) {
    //如果node.tagName == "A"则不处理 
    if (TV2_NodeIsLeaf(node))
        return null;
    var childNodsDivId = node.id + "Nodes";
    return document.getElementById(childNodsDivId);
}
//find node in element 
function TV2i_GetNodeInElement(tree, element) {
    var node = TV2i_GetNodeInElementA(tree, element);
    if (node == null) {
        node = TV2i_GetNodeInElementInput(tree, element);
    }
    return node;
}
//find "A" node 
function TV2i_GetNodeInElementA(tree, element) {
    var as = WebForm_GetElementsByTagName(element, "A");
    if (as == null || as.length == 0)
        return null;
    var regexp = new RegExp("^" + tree.id + "n\\d+$");
    for (var i = 0; i < as.length; i++) {
        if (as[i].id.match(regexp)) {
            return as[i];
        }
    }
    return null;
}
//find "INPUT" node 
function TV2i_GetNodeInElementInput(tree, element) {
    var as = WebForm_GetElementsByTagName(element, "INPUT");
    if (as == null || as.length == 0)
        return null;
    var regexp = new RegExp("^" + tree.id + "n\\d+");
    for (var i = 0; i < as.length; i++) {
        if (as[i].id.match(regexp)) {
            return as[i];
        }
    }
    return null;
}
//get checkbox of node 
function TV2i_NodeGetCheckBox(node) {
    if (IsCheckBox(node))
        return node;
    var id = node.id + "CheckBox";
    return document.getElementById(id);
} 

//
function postBackByObject() {
    var o = window.event.srcElement;
    if (o.tagName == "INPUT" && o.type == "checkbox") {
        __doPostBack("", "");
    }
}
function onTreeViewClick(evt) {
    evt = evt || window.event;
    var obj = (evt.target) ? evt.target : evt.srcElement;
    if (obj.tagName == "INPUT" && obj.type == "checkbox") {
        //var node = obj.parentNode.parentNode.parentNode.parentNode.nextSibling;
        //               TD         TR         TBODY      TABLE      DIV( 子节点的容器)
        //alert(obj.parentNode.parentNode.parentNode.tagName);
        var node = document.getElementById(obj.id.replace("CheckBox", "Nodes"));
        var nodes;
        if (node) {
            nodes = node.getElementsByTagName("INPUT");
            for (var j = 0; j < nodes.length; j++) {
                if (nodes[j].type == "checkbox") {
                    nodes[j].checked = obj.checked;
                }
            }
        }
    }
}
        